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
        private AutoMock _autoMock;
        private Mock<IMapper> _mapperMock;
        private EditGroupModel _editGroupModel;
        private Mock<IGroupService> _groupServiceMock;

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
        public void SetUp()
        {
            _groupServiceMock = _autoMock.Mock<IGroupService>();
            _mapperMock = _autoMock.Mock<IMapper>();
            _editGroupModel = _autoMock.Create<EditGroupModel>();
        }
        
        [TearDown]
        public void TearDown()
        {
            _groupServiceMock?.Reset();
            _mapperMock?.Reset();
        }

        [Test]
        public void LoadModelData_GroupExists_LoadProperties()
        {
            // Arrange
            const int id = 5;

            var group = new Group
            {
                Id = id,
                Name = "My Group",
                ApplicationUserId = Guid.NewGuid()
            };

            _groupServiceMock.Setup(x => x.GetGroup(id)).Returns(group).Verifiable();

            _mapperMock.Setup(x => x.Map(
                group, It.IsAny<EditGroupModel>()
            )).Verifiable();

            // Act
            _editGroupModel.LoadModelData(id);

            // Assert
            // Assert.AreEqual(id, _editGroupModel.Id);
            _groupServiceMock.VerifyAll();
            _mapperMock.VerifyAll();
        }
    }
}