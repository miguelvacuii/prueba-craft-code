﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ExcelImport.UseCases
{
    public class UploadUsersUseCase
    {
        private test2Entities repository = new test2Entities();

        private UploadUsersUseCase()
        {
        }

        public JsonResult Invoke(User users, HttpPostedFileBase fileUpload)
        {

            string fileName = fileUpload.FileName;
            string targetPath = Server.MapPath("~/Doc/");
            fileUpload.SaveAs(targetPath + fileName);
            string pathToExcelFile = targetPath + fileName;

            CreateConnection(fileName, pathToExcelFile);

            List<User> userList = GetUsersFromExcel(pathToExcelFile);

            List<string> errorMessage = SaveUsers(userList);

            if (errorMessage.Any())
            {
                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }

            DeleteFile(pathToExcelFile);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        private void CreateConnection(string fileName, string pathToExcelFile)
        {
            string connectionString = "";
            if (fileName.EndsWith(".xls"))
            {
                connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
            }
            else if (fileName.EndsWith(".xlsx"))
            {
                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
            }

            if (connectionString != "")
            {
                var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                var dataSet = new DataSet();
                adapter.Fill(dataSet, "ExcelTable");
                DataTable dtable = dataSet.Tables["ExcelTable"];
            }
        }

        private List<User> GetUsersFromExcel(string pathToExcelFile)
        {
            string sheetName = "Sheet1";
            var excelFile = new ExcelQueryFactory(pathToExcelFile);

            return (from rows in excelFile.Worksheet<User>(sheetName) select rows) as List<User>;
        }

        private List<string> SaveUsers(List<User> userList)
        {
            List<string> errorMessage = new List<string>();

            foreach (User user in userList)
            {
                try
                {
                    if (user.Name != "" && user.Address != "" && user.ContactNo != "")
                    {
                        User userUpdated = new User();
                        userUpdated.Name = user.Name;
                        userUpdated.Address = user.Address;
                        userUpdated.ContactNo = user.ContactNo;
                        repository.Users.Add(userUpdated);
                        repository.SaveChanges();
                    }
                    else
                    {
                        errorMessage.Add("<ul>");
                        if (user.Name == "" || user.Name == null) errorMessage.Add("<li> name is required</li>");
                        if (user.Address == "" || user.Address == null) errorMessage.Add("<li> Address is required</li>");
                        if (user.ContactNo == "" || user.ContactNo == null) errorMessage.Add("<li>ContactNo is required</li>");
                        errorMessage.Add("</ul>");
                        errorMessage.ToArray();

                    }
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        private void DeleteFile(String pathToExcelFile)
        {
            if ((System.IO.File.Exists(pathToExcelFile)))
            {
                System.IO.File.Delete(pathToExcelFile);
            }
        }

    }
}