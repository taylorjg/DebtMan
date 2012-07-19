using NUnit.Framework;

namespace DebtMan.DomainModel.Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class DebtManagementPlanTests
    {
        [Test]
        public void DebtManagementPlan_Debtor1CompanyA_IsCalculatedCorrectly()
        {
            var debtor =
                new Debtor
                    {
                        Name = "John Nogan",
                        Income = 980m,
                        Expenditure = 670m,
                        Company = Company.CompanyA,
                        Debts = new[]
                                        {
                                            new Debt {AmountOwed = 3000m},
                                            new Debt {AmountOwed = 12000m},
                                            new Debt {AmountOwed = 100m},
                                            new Debt {AmountOwed = 4000m}
                                        }
                    };

            var dmp = new DebtManagementPlan(debtor);

            Assert.That(dmp.MonthlyManagementFee, Is.EqualTo(46.5m));
            Assert.That(dmp.CreditorRepayments, Has.Count.EqualTo(4));
        }

        [Test]
        public void DebtManagementPlan_Debtor2CompanyC_IsCalculatedCorrectly()
        {
            var debtor =
                new Debtor
                    {
                        Name = "Paul A’rdé",
                        Income = 1560m,
                        Expenditure = 1399m,
                        Company = Company.CompanyC,
                        Debts = new[]
                                        {
                                            new Debt {AmountOwed = 300m},
                                            new Debt {AmountOwed = 2400m},
                                            new Debt {AmountOwed = 10000m},
                                            new Debt {AmountOwed = 2000m},
                                            new Debt {AmountOwed = 919m}
                                        }
                    };

            var dmp = new DebtManagementPlan(debtor);

            Assert.That(dmp.MonthlyManagementFee, Is.EqualTo(100.0m));
            Assert.That(dmp.CreditorRepayments, Has.Count.EqualTo(5));
        }

        [Test]
        public void DebtManagementPlan_Debtor3CompanyB_IsCalculatedCorrectly()
        {
            var debtor =
                new Debtor
                    {
                        Name = "Miss T. Un-terre",
                        Income = 500m,
                        Expenditure = 400m,
                        Company = Company.CompanyB,
                        Debts = new[]
                                        {
                                            new Debt {AmountOwed = 100m},
                                            new Debt {AmountOwed = 2400m},
                                            new Debt {AmountOwed = 5000m}
                                        }
                    };

            var dmp = new DebtManagementPlan(debtor);

            Assert.That(dmp.MonthlyManagementFee, Is.EqualTo(30.0m));
            Assert.That(dmp.CreditorRepayments, Has.Count.EqualTo(3));
        }

        [Test]
        public void DebtManagementPlan_Debtor4CompanyC_IsCalculatedCorrectly()
        {
            var debtor =
                new Debtor
                    {
                        Name = "David Simmer",
                        Income = 2000m,
                        Expenditure = 1000m,
                        Company = Company.CompanyC,
                        Debts = new[]
                                        {
                                            new Debt {AmountOwed = 100m},
                                            new Debt {AmountOwed = 200m},
                                            new Debt {AmountOwed = 600m},
                                            new Debt {AmountOwed = 2000m},
                                            new Debt {AmountOwed = 7370m}
                                        }
                    };

            var dmp = new DebtManagementPlan(debtor);

            Assert.That(dmp.MonthlyManagementFee, Is.EqualTo(100.0m));
            Assert.That(dmp.CreditorRepayments, Has.Count.EqualTo(5));
        }

        [Test]
        public void DebtManagementPlan_GivenADebtorWithATotalAmountOwedOfZero_DoesNotThrowAnException()
        {
            var debtor =
                new Debtor
                    {
                        Name = "Rick Rolling",
                        Income = 2000m,
                        Expenditure = 1200m,
                        Company = Company.CompanyA,
                        Debts =
                            new[]
                                {
                                    new Debt {AmountOwed = 0m}
                                }
                    };

            var dmp = new DebtManagementPlan(debtor);
        }
    }

    // ReSharper restore InconsistentNaming
}
