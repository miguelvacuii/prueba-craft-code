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
        public JsonResult UploadExcel(User users, HttpPostedFileBase fileUpload)
        {

            List<string> errorMessage = new List<string>();

            if (fileUpload == null) {
                errorMessage.Add("<ul>");
                if (fileUpload == null) errorMessage.Add("<li>Please choose Excel file</li>");
                errorMessage.Add("</ul>");
                errorMessage.ToArray();
                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }

            if (fileUpload.ContentType != "application/vnd.ms-excel" || fileUpload.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") {
                errorMessage.Add("<ul>");
                errorMessage.Add("<li>Only Excel file format is allowed</li>");
                errorMessage.Add("</ul>");
                errorMessage.ToArray();
                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }

            return UploadUsersUseCase.Invoke(users, fileUpload);
        }
    }
}
