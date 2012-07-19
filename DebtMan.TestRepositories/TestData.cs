using System;
using System.Collections.Generic;
using System.Reflection;
using DebtMan.DomainModel;
using DebtMan.DomainModel.Repositories;

namespace DebtMan.TestRepositories
{
    public static class TestData
    {
        public static IDebtorRepository CreateDebtorRepository()
        {
            var items =
                new List<Debtor>
                    {
                        CreateDebtor1(),
                        CreateDebtor2(),
                        CreateDebtor3(),
                        CreateDebtor4()
                    };
            var debtorTestRepository = new DebtorTestRepository(items);
            return debtorTestRepository;
        }

        private static Debtor CreateDebtor1()
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
            SetIdUsingReflection(debtor, 1);
            return debtor;
        }

        private static Debtor CreateDebtor2()
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
            SetIdUsingReflection(debtor, 2);
            return debtor;
        }

        private static Debtor CreateDebtor3()
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
            SetIdUsingReflection(debtor, 3);
            return debtor;
        }

        private static Debtor CreateDebtor4()
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
            SetIdUsingReflection(debtor, 4);
            return debtor;
        }

        private static void SetFieldUsingReflection(object target, string fieldName, object value)
        {
            var fieldInfo = target.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo == null) {
                throw new ApplicationException(
                    String.Format(
                        "SetFieldUsingReflection - failed to set field \"{0}\" to value \"{1}\".",
                        fieldName,
                        value));
            }

            fieldInfo.SetValue(target, value);
        }

        private static void SetIdUsingReflection(object target, int id)
        {
            SetFieldUsingReflection(target, "id", id);
        }
    }
}
