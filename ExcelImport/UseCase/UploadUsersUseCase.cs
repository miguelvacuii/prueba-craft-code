using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ExcelImport.Models.User;
using ExcelImport.Repository;
using ExcelImport.Repository.Exception;
using ExcelImport.Repository.User;
using ExcelImport.Shared;

namespace ExcelImport.UseCases
{
    public class UploadUsersUseCase
    {
        private readonly IUserRepository repository;

        private UploadUsersUseCase(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Invoke(HttpPostedFileBase fileUpload)
        {
            string pathToExcelFile = SaveFileAndReturnPath(fileUpload);

            dynamic userList = GetUsersFromExcel(pathToExcelFile);

            SaveUsers(userList);

            DeleteFile(pathToExcelFile);
        }

        private string SaveFileAndReturnPath(HttpPostedFileBase fileUpload) {
            string fileName = fileUpload.FileName;
            string targetPath = Server.MapPath("~/Doc/");
            fileUpload.SaveAs(targetPath + fileName);
            return targetPath + fileName;
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
