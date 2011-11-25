using System;
using DebtMan.DomainModel;
using NUnit.Framework;

namespace DebtMan.DomainModel.Tests
{
    [TestFixture]
    internal class DebtManagementPlanTests
    {
        [Test]
        public void DebtManagementPlan_Debtor1CompanyA_IsCalculatedCorrectly()
        {
            var debtor = new Debtor();
            debtor.Name = "John Nogan";
            debtor.Income = 980m;
            debtor.Expenditure = 670m;
            debtor.Company = Company.CompanyA;
            debtor.Creditors = new Creditor[] {
                new Creditor() { AmountOwed = 3000m },
                new Creditor() { AmountOwed = 12000m },
                new Creditor() { AmountOwed = 100m },
                new Creditor() { AmountOwed = 4000m }
            };

            var dmp = new DebtManagementPlan(debtor);

            Assert.That(dmp.MonthlyManagementFee, Is.EqualTo(46.5m));
            Assert.That(dmp.CreditorRepayments, Has.Count.EqualTo(4));
        }

        [Test]
        public void DebtManagementPlan_Debtor2CompanyC_IsCalculatedCorrectly()
        {
            var debtor = new Debtor();
            debtor.Name = "Paul A’rdé";
            debtor.Income = 1560m;
            debtor.Expenditure = 1399m;
            debtor.Company = Company.CompanyC;
            debtor.Creditors = new Creditor[] {
                new Creditor() { AmountOwed = 300m },
                new Creditor() { AmountOwed = 2400m },
                new Creditor() { AmountOwed = 10000m },
                new Creditor() { AmountOwed = 2000m },
                new Creditor() { AmountOwed = 919m }
            };

            var dmp = new DebtManagementPlan(debtor);

            Assert.That(dmp.MonthlyManagementFee, Is.EqualTo(100.0m));
            Assert.That(dmp.CreditorRepayments, Has.Count.EqualTo(5));
        }

        [Test]
        public void DebtManagementPlan_Debtor3CompanyB_IsCalculatedCorrectly()
        {
            var debtor = new Debtor();
            debtor.Name = "Miss T. Un-terre";
            debtor.Income = 500m;
            debtor.Expenditure = 400m;
            debtor.Company = Company.CompanyB;
            debtor.Creditors = new Creditor[] {
                new Creditor() { AmountOwed = 100m },
                new Creditor() { AmountOwed = 2400m },
                new Creditor() { AmountOwed = 5000m }
            };

            var dmp = new DebtManagementPlan(debtor);

            Assert.That(dmp.MonthlyManagementFee, Is.EqualTo(30.0m));
            Assert.That(dmp.CreditorRepayments, Has.Count.EqualTo(3));
        }

        [Test]
        public void DebtManagementPlan_Debtor4CompanyC_IsCalculatedCorrectly()
        {
            var debtor = new Debtor();
            debtor.Name = "David Simmer";
            debtor.Income = 2000m;
            debtor.Expenditure = 1000m;
            debtor.Company = Company.CompanyC;
            debtor.Creditors = new Creditor[] {
                new Creditor() { AmountOwed = 100m },
                new Creditor() { AmountOwed = 200m },
                new Creditor() { AmountOwed = 600m },
                new Creditor() { AmountOwed = 2000m },
                new Creditor() { AmountOwed = 7370m }
            };

            var dmp = new DebtManagementPlan(debtor);

            Assert.That(dmp.MonthlyManagementFee, Is.EqualTo(100.0m));
            Assert.That(dmp.CreditorRepayments, Has.Count.EqualTo(5));
        }
    }
}
