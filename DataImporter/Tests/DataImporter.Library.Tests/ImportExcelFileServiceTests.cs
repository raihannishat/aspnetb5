using Autofac.Extras.Moq;
using DataImporter.Library.Services;
using DataImporter.Library.BusinessObjects;
using DataImporter.Library.UnitOfWorks;
using DataImporter.Library.Repositories;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using System.Collections.Generic;

namespace DataImporter.Library.Tests
{
    [ExcludeFromCodeCoverage]
    public class ImportExcelFileServiceTests
    {
        private AutoMock _autoMock;
        private Mock<IDataImporterUnitOfWork> _dataImporterUnitOfWorkMock;
        private Mock<IImportExcelFileRepository> _importExcelFileRepositoryMock;
        private Mock<IExcelRowRepository> _excelRowRepositoryMock;
        private Mock<IExcelColumnRepository> _excelColumnRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private IImportExcelFileService _importExcelFileService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _autoMock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _autoMock?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            _dataImporterUnitOfWorkMock = _autoMock.Mock<IDataImporterUnitOfWork>();
            _importExcelFileRepositoryMock = _autoMock.Mock<IImportExcelFileRepository>();
            _excelRowRepositoryMock = _autoMock.Mock<IExcelRowRepository>();
            _excelColumnRepositoryMock = _autoMock.Mock<IExcelColumnRepository>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _importExcelFileService = _autoMock.Create<IImportExcelFileService>();
        }

        [TearDown]
        public void TearDown()
        {
            _dataImporterUnitOfWorkMock?.Reset();
            _excelRowRepositoryMock?.Reset();
            _excelColumnRepositoryMock.Reset();
            _mapperMock.Reset();
        }

        [Test]
        public void ImportExcelFile_ImportFileExists_GetAllImportExcelFile()
        {
            // Arrange
            const int id = 15;
            const int groupId = 25;
            const string status = "Working";

            IList<Entities.ImportExcelFile> importExcelFileList = new List<Entities.ImportExcelFile>
            {
                new Entities.ImportExcelFile
                {
                    Id = id,
                    GroupId = groupId,
                    ImportStatus = status
                }
            };

            _importExcelFileRepositoryMock.Setup(x => x.GetAll())
                .Returns(importExcelFileList)
                .Verifiable();

            _dataImporterUnitOfWorkMock.Setup(x => x.ImportExcelFileRepository)
                .Returns(_importExcelFileRepositoryMock.Object)
                .Verifiable();

            // Act

            _importExcelFileService.ImportExcelFile();

            // Assert
        }
    }
}