using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ExcelImport.Models.User;
using ExcelImport.Repository;
using ExcelImport.Repository.Exception;
using ExcelImport.Repository.User;

namespace ExcelImport.UseCases
{
    public class UploadUsersUseCase
    {
        private readonly IUserRepository repository;

        private UploadUsersUseCase(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Invoke(User users, HttpPostedFileBase fileUpload)
        {

            string fileName = fileUpload.FileName;
            string targetPath = Server.MapPath("~/Doc/");
            fileUpload.SaveAs(targetPath + fileName);
            string pathToExcelFile = targetPath + fileName;

            CreateConnection(fileName, pathToExcelFile);

            dynamic userList = GetUsersFromExcel(pathToExcelFile);

            List<string> errorMessage = SaveUsers(userList);

            DeleteFile(pathToExcelFile);
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

        private dynamic GetUsersFromExcel(string pathToExcelFile)
        {
            string sheetName = "Sheet1";
            var excelFile = new ExcelQueryFactory(pathToExcelFile);

            return (from rows in excelFile.Worksheet<User>(sheetName) select rows) as dynamic;
        }

        private void SaveUsers(dynamic userList)
        {
            foreach (var user in userList) {
                try {
                    UserName userName = new UserName(user.Name);
                    UserAddress userAddress = new UserAddress(user.Address);
                    UserContactNumber userContactNumber = new UserContactNumber(user.ContactNo);

                    User userUpdated = User.Create(userName, userAddress, userContactNumber);
                    repository.Add(user);
                    repository.SaveChanges();
                } catch (DbEntityValidationException ex) {
                    throw RepositoryException.FromEntity("User", ex);
                }
            }
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
