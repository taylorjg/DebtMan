using System;
using NUnit.Framework;

namespace DebtMan.DomainModel.Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class CompanyExtensionsTests
    {
        [Test]
        public void CompanyToDisplayName_GivenCompanyB_ReturnsDebtDestructor()
        {
            // Arrange
            const Company company = Company.CompanyB;

            // Act
            var companyName = company.CompanyToDisplayName();

            // Assert
            Assert.That(companyName, Is.EqualTo("DebtDestructor"));
        }

        [Test]
        public void CompanyToDisplayName_GivenBogusValue_BogusValueToString()
        {
            // Arrange
            const Company company = (Company)5;

            // Act
            var companyName = company.CompanyToDisplayName();

            // Assert
            Assert.That(companyName, Is.EqualTo(company.ToString()));
        }

        [Test]
        public void DisplayNameToCompany_GivenMoneyHelper_ReturnsCompanyC()
        {
            // Arrange
            const string companyName = "MoneyHelper";

            // Act
            var company = companyName.DisplayNameToCompany();

            // Assert
            Assert.That(company, Is.EqualTo(Company.CompanyC));
        }

        [Test]
        public void DisplayNameToCompany_GivenBogusValue_ThrowsException()
        {
            // Arrange
            const string companyName = "Bogus";

            // Act, Assert
            Assert.Throws<ArgumentException>(() => companyName.DisplayNameToCompany());
        }
    }

    // ReSharper restore InconsistentNaming
}
