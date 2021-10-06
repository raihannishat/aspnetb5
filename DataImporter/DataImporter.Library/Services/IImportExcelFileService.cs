﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Library.BusinessObjects;

namespace DataImporter.Library.Services
{
    public interface IImportExcelFileService
    {
        void CreateImportExcelFile(ImportExcelFile importExcelFile);
        (IList<ImportExcelFile> records, int total, int totalDisplay) 
            GetImportExcelFiles(int pageIndex, int pageSize, string searchText, string sortText);
        ImportExcelFile GetImportExcelFile(int id);
        void UpdateImportExcelFile(ImportExcelFile importExcelFile);
        void DeleteImportExcelFile(int importExcelFileId);
    }
}
