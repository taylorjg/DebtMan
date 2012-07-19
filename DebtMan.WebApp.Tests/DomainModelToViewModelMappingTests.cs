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
    internal class DomainModelToViewModelMappingTests
    {
        [SetUp]
        public void SetUp()
        {
            AutoMapperBootstrapper.Configure();
        }

        [Test]
        public void Map_GivenAFullyPopulatedDomainModelObject_ReturnsACorrectlyMappedViewModelObject()
        {
            // Arrange
            var dm =
                new Debtor(2)
                    {
                        Name = "AAA",
                        Company = Company.CompanyB,
                        Income = 333.3m,
                        Expenditure = 222.2m,
                        Debts =
                            new[]
                                {
                                    new Debt {AmountOwed = 10.0m},
                                    new Debt {AmountOwed = 20.0m},
                                    new Debt {AmountOwed = 30.0m}
                                }
                    };

            // Act
            var vm = Mapper.Map<Debtor, DebtorViewModel>(dm);

            // Assert
            Assert.That(vm.Id, Is.EqualTo(dm.Id));
            Assert.That(vm.Name, Is.EqualTo(dm.Name));
            Assert.That(vm.CompanyName, Is.EqualTo(dm.Company.CompanyToDisplayName()));
            Assert.That(vm.Income, Is.EqualTo(dm.Income));
            Assert.That(vm.Expenditure, Is.EqualTo(dm.Expenditure));
            Assert.That(vm.Debts, Has.Length.EqualTo(dm.Debts.Count()));
            Assert.That(vm.Debts[0].AmountOwed, Is.EqualTo(10.0m));
            Assert.That(vm.Debts[1].AmountOwed, Is.EqualTo(20.0m));
            Assert.That(vm.Debts[2].AmountOwed, Is.EqualTo(30.0m));
        }
    }

    // ReSharper restore InconsistentNaming
}
