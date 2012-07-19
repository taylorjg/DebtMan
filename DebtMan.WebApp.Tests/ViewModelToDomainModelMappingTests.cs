using System.Linq;
using DebtMan.DomainModel;
using DebtMan.WebApp.Models;
using DebtMan.WebApp.Bootstrappers;
using DebtMan.WebApp.Mappers;
using AutoMapper;
using NUnit.Framework;

namespace DebtMan.WebApp.Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class ViewModelToDomainModelMappingTests
    {
        [SetUp]
        public void SetUp()
        {
            AutoMapperBootstrapper.Configure();
        }

        [Test]
        public void Map_GivenAFullyPopulatedViewModelObject_ReturnsACorrectlyMappedDomainModelObject()
        {
            // Arrange
            var vm =
                new DebtorViewModel
                    {
                        Id = 14,
                        Name = "XXX",
                        CompanyName = "MoneyHelper",
                        Income = 444.4m,
                        Expenditure = 2323.23m,
                        Debts =
                            new[]
                                {
                                    new DebtViewModel {AmountOwed = 40.0m},
                                    new DebtViewModel {AmountOwed = 50.0m}
                                }
                    };

            // Act
            var dm = new Debtor(vm.Id);
            Mapper.Map<DebtorViewModel, Debtor>(vm, dm);

            // Assert
            Assert.That(dm.Id, Is.EqualTo(vm.Id));
            Assert.That(dm.Name, Is.EqualTo(vm.Name));
            Assert.That(dm.Company, Is.EqualTo(Company.CompanyC));
            Assert.That(dm.Income, Is.EqualTo(vm.Income));
            Assert.That(dm.Expenditure, Is.EqualTo(vm.Expenditure));
            Assert.That(dm.Debts, Has.Count.EqualTo(vm.Debts.Length));
            Assert.That(dm.Debts.Skip(0).First().AmountOwed, Is.EqualTo(40.0m));
            Assert.That(dm.Debts.Skip(1).First().AmountOwed, Is.EqualTo(50.0m));
        }
    }

    // ReSharper restore InconsistentNaming
}
