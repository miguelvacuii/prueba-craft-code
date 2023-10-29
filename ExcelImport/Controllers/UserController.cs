using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ExcelImport.Models;
using LinqToExcel;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using ExcelImport.UseCases;
using Microsoft.AspNetCore.Http;
using ExcelImport.Controllers.Exception;

namespace ExcelImport.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public FileResult DownloadExcel()
        {
            string path = "/Doc/Users.xlsx";
            return File(path, "application/vnd.ms-excel", "Users.xlsx");
        }

        [HttpPost]
        public IActionResult UploadExcel(HttpPostedFileBase fileUpload)
        {
            const string CONTENT_TYPE_EXCEL = "application/vnd.ms-excel";
            const string CONTENT_TYPE_XML = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            if (fileUpload == null) {
                throw InvalidFileException.FromNull();
            }

            if (fileUpload.ContentType != CONTENT_TYPE_EXCEL || fileUpload.ContentType != CONTENT_TYPE_XML) {
                throw InvalidFileException.FromContentType();
            }

            try {
                UploadUsersUseCase.Invoke(fileUpload);
                return StatusCode(200);
            } catch (System.Exception exception) {
                return StatusCode(422, exception.Message);
            }

            
        }
    }
}
