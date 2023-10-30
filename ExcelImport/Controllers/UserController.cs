using Microsoft.AspNetCore.Mvc;
using ExcelImport.UseCases;
using ExcelImport.Shared.Service.FileProcessor;

namespace ExcelImport.Controllers
{
    public class UserController : Controller
    {
        private readonly UploadUsersUseCase uploadUsersUseCase;

        public UserController(UploadUsersUseCase uploadUsersUseCase)
        {
            this.uploadUsersUseCase = uploadUsersUseCase;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public FileResult DownloadUsers()
        {
            const string PATH = "/Doc/Users.xlsx";
            const string CONTENT_TYPE = "application/vnd.ms-excel";
            const string FILE_NAME = "Users.xlsx";
            return File(PATH, CONTENT_TYPE, FILE_NAME);
        }

        [HttpPost]
        public IActionResult UploadUsers(HttpPostedFileBase fileUpload)
        {
            try {
                uploadUsersUseCase.Invoke(fileUpload);
                return StatusCode(200);
            } catch (System.Exception exception) {
                return StatusCode(422, exception.Message);
            }

            
        }
    }
}
