using System;
using System.Web.Mvc;
using DebtMan.DomainModel;
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
    internal class DebtorsControllerTests
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
            var controller = new DebtorsController(fakeDebtorRepository);

            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => controller.Details(2));
        }

        [Test]
        public void Details_GivenIdOfKnownDebtor_ReturnsAViewResult()
        {
            // Arrange
            var fakeDebtorRepository = A.Fake<IDebtorRepository>();
            var stubDomainDebtor = DebtorBuilder.Build(2);
            A.CallTo(() => fakeDebtorRepository.FindById(2)).Returns(stubDomainDebtor);
            var controller = new DebtorsController(fakeDebtorRepository);

            // Act
            var actionResult = controller.Details(2);

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
            var controller = new DebtorsController(fakeDebtorRepository);

            // Act
            var viewResult = controller.Details(2) as ViewResult;

            // Assert
            Assert.That(viewResult.Model, Is.InstanceOf<DebtorViewModel>());
        }
        // ReSharper restore PossibleNullReferenceException

        [Test]
        public void DeleteMethodPost_GivenIdOfKnownDebtor_DeletesObjectInRepository()
        {
            // Arrange
            var fakeDebtorRepository = A.Fake<IDebtorRepository>();
            var stubDomainDebtor = DebtorBuilder.Build(2);
            A.CallTo(() => fakeDebtorRepository.FindById(2)).Returns(stubDomainDebtor);
            var controller = new DebtorsController(fakeDebtorRepository);

            // Act
            controller.DeletePost(2);

            // Assert
            A.CallTo(() => fakeDebtorRepository.MakeTransient(A<Debtor>.That.Matches(entity => entity.Id == 2))).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        // ReSharper disable PossibleNullReferenceException
        public void EditMethodPost_GivenInvalidEditModel_DoesNotCallMakePersistentOnTheDebtorRepository()
        {
            // Arrange
            var fakeDebtorRepository = A.Fake<IDebtorRepository>();
            var controller = new DebtorsController(fakeDebtorRepository);
            var editModelDebtor = new DebtorEditModel {CompanyName = "MoneyHelper"};
            controller.ModelState.AddModelError("some_key", @"some_error_message");

            // Act
            var viewResult = controller.Edit(editModelDebtor) as ViewResult;

            // Assert
            A.CallTo(() => fakeDebtorRepository.MakePersistent(A<Debtor>.Ignored)).MustNotHaveHappened();
            Assert.That(viewResult.ViewName, Is.EqualTo("CreateOrEdit"));
        }
        // ReSharper restore PossibleNullReferenceException
    }

    // ReSharper restore InconsistentNaming
}
