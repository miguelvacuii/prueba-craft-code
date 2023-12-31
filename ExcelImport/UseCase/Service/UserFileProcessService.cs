﻿using ExcelImport.Models.User;
using ExcelImport.Shared.Service.FileProcessor;
using ExcelImport.Shared.Service.FileProcessor.Exception;

namespace ExcelImport.UseCase.Service
{
    public class UserFileProcessService : FileProcessService
    {
        private readonly IFileProcessorLibrary excelQueryFactory;
        private readonly IServer server;

        private const string SHEET_NAME = "Sheet1";
        private const string CONTENT_TYPE_EXCEL = "application/vnd.ms-excel";
        private const string CONTENT_TYPE_XML = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


        public UserFileProcessService(IFileProcessorLibrary fileProcessorLibrary, IServer server) : base (
            fileProcessorLibrary, server) {}

        public override string SaveFileAndReturnPath(HttpPostedFileBase file)
        {
            
            if (file == null)
            {
                throw FileProcessException.FromNull();
            }

            if (file.ContentType != CONTENT_TYPE_EXCEL || file.ContentType != CONTENT_TYPE_XML)
            {
                throw FileProcessException.FromContentType("Excel");
            }

            return base.SaveFileAndReturnPath(file);
        }

        public override dynamic ProcessFileContent(string path)
        {
            ExcelFile excelFile = excelQueryFactory.ReadFile(path);

            return (from rows in excelFile.Worksheet<User>(SHEET_NAME) select rows) as dynamic;
        }
    }
}
