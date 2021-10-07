using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Library.UnitOfWorks;
using EO = DataImporter.Library.Entities;
using Autofac;
using GemBox.Spreadsheet;

namespace DataImporter.Worker.Model
{
    public class WorkerModel
    {
        private readonly IDataImporterUnitOfWork _dataImporterUnitOfWork;

        public WorkerModel()
        {
            _dataImporterUnitOfWork = Worker.AutofacContainer.Resolve<IDataImporterUnitOfWork>();
        }

        public void GetAllStatus()
        {
            var status = _dataImporterUnitOfWork.ImportExcelFileRepository.GetAll();

            string filePath = null;
            var rows = new EO.ExcelRow();

            foreach (var item in status)
            {
                if (item.ImportStatus.Equals("Working"))
                {
                    filePath = item.Location;
                    rows.GroupId = item.GroupId;
                    rows.UploadDate = item.ImportDate;
                    item.ImportStatus = "Success";
                    _dataImporterUnitOfWork.ExcelRowRepository.Add(rows);
                    _dataImporterUnitOfWork.Save();
                }

                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                var workbook = ExcelFile.Load(filePath);
                var list = new List<string>();

                foreach (var worksheet in workbook.Worksheets)
                {
                    int count = 0;

                    foreach (var row in worksheet.Rows)
                    {
                        foreach (var cell in row.AllocatedCells)
                        {
                            if (row.Name == "1")
                            {
                                list.Add(cell.Value.ToString());
                            }
                            else if (cell.ValueType != CellValueType.Null)
                            {
                                var columns = new EO.ExcelColumn();
                                columns.ExcelRowId = rows.Id;
                                columns.Column = list[count++];
                                columns.Value = cell.Value.ToString();
                                _dataImporterUnitOfWork.ExcelColumnRepository.Add(columns);
                                _dataImporterUnitOfWork.Save();
                            }
                        }

                        count = 0;
                    }
                }
            }
        }
    }
}
