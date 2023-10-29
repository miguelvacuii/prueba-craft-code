using System;
using System.Data;
using System.Linq;
using ExcelImport.Models.User;
using ExcelImport.Repository.User;
using ExcelImport.UseCase.Service;

namespace ExcelImport.UseCases
{
    public class UploadUsersUseCase
    {
        private readonly IUserRepository repository;
        private readonly UserFactory userFactory;

        private UploadUsersUseCase(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Invoke(HttpPostedFileBase fileUpload)
        {
            string pathToExcelFile = SaveFileAndReturnPath(fileUpload);

            dynamic userList = GetUsersFromExcel(pathToExcelFile);

            foreach (var user in userList)
            {
                User userUpdated = userFactory.CreateUserFromSource(user);
                repository.Add(userUpdated);
            }

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

        private void DeleteFile(String pathToExcelFile)
        {
            if ((System.IO.File.Exists(pathToExcelFile)))
            {
                System.IO.File.Delete(pathToExcelFile);
            }
        }

    }
}
