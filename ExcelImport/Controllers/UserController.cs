using Microsoft.AspNetCore.Mvc;
using ExcelImport.UseCases;
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
