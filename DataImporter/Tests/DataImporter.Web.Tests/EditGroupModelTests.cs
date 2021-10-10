using Autofac.Extras.Moq;
using AutoMapper;
using DataImporter.Library.BusinessObjects;
using DataImporter.Library.Services;
using DataImporter.Web.Models.Groups;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System;

namespace DataImporter.Web.Tests
{
    [ExcludeFromCodeCoverage]
    public class EditGroupModelTests
    {
        private AutoMock _mock;
        private Mock<IMapper> _mapperMock;
        private Mock<IGroupService> _groupServiceMock;
        private EditGroupModel _editGroupModel;

        [OneTimeSetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            _groupServiceMock = _mock.Mock<IGroupService>();
            _mapperMock = _mock.Mock<IMapper>();
            _editGroupModel = _mock.Create<EditGroupModel>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _groupServiceMock?.Reset();
            _mapperMock?.Reset();
        }

        [Test]
        public void LoadModelData_GroupExists_LoadsProperties()
        {
            // Arrange
            const int id = 3;

            var group = new Group
            {
                Id = id,
                Name = "Dev Skill",
                ApplicationUserId = Guid.NewGuid()
            };

            _groupServiceMock.Setup(x => x.GetGroup(id)).Returns(group).Verifiable();
            _mapperMock.Setup(x => x.Map(group, It.IsAny<EditGroupModel>())).Verifiable();

            // Act
            _editGroupModel.LoadModelData(id);

            // Assert
            _groupServiceMock.VerifyAll();
            _mapperMock.VerifyAll();
        }
    }
}