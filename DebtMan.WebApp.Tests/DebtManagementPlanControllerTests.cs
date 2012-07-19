using System;
using System.Web.Mvc;
using DebtMan.DomainModel.Repositories;
using DebtMan.WebApp.Bootstrappers;
using DebtMan.WebApp.Controllers;
using DebtMan.WebApp.Models;
using DebtMan.WebApp.Tests.Builders;
using NUnit.Framework;
using FakeItEasy;

namespace DebtMan.WebApp.Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class DebtManagementPlanControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            AutoMapperBootstrapper.Configure();
        }

        [Test]
        public void Details_GivenIdOfUnknownDebtor_ThrowsException()
        {
            // Arrange
            var fakeDebtorRepository = A.Fake<IDebtorRepository>();
            A.CallTo(() => fakeDebtorRepository.FindById(2)).Returns(null);
            var controller = new DebtManagementPlanController(fakeDebtorRepository);

            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => controller.Details(2, null));
        }

        [Test]
        public void Details_GivenIdOfKnownDebtor_ReturnsAViewResult()
        {
            // Arrange
            var fakeDebtorRepository = A.Fake<IDebtorRepository>();
            var stubDomainDebtor = DebtorBuilder.Build(2);
            A.CallTo(() => fakeDebtorRepository.FindById(2)).Returns(stubDomainDebtor);
            var controller = new DebtManagementPlanController(fakeDebtorRepository);

            // Act
            var actionResult = controller.Details(2, null);

            // Assert
            Assert.That(actionResult, Is.InstanceOf<ViewResult>());
        }

        [Test]
        // ReSharper disable PossibleNullReferenceException
        public void Details_GivenIdOfKnownDebtor_ReturnsAViewResultWithCorrectViewModelType()
        {
            // Arrange
            var fakeDebtorRepository = A.Fake<IDebtorRepository>();
            var stubDomainDebtor = DebtorBuilder.Build(2);
            A.CallTo(() => fakeDebtorRepository.FindById(2)).Returns(stubDomainDebtor);
            var controller = new DebtManagementPlanController(fakeDebtorRepository);

            // Act
            var viewResult = controller.Details(2, null) as ViewResult;

            // Assert
            Assert.That(viewResult.Model, Is.InstanceOf<DebtManagementPlanViewModel>());
        }
        // ReSharper restore PossibleNullReferenceException
    }

    // ReSharper restore InconsistentNaming
}
