using DebtMan.DomainModel;

namespace DebtMan.WebApp.Tests.Builders
{
    internal static class DebtorBuilder
    {
        public static Debtor Build(int id)
        {
            var debtor =
                new Debtor
                    {
                        Company = Company.CompanyB,
                        Name = "Stub Debtor Name",
                        Expenditure = 1000.0m,
                        Income = 2000.0m,
                        Debts = new[]
                                        {
                                            new Debt {AmountOwed = 100.0m},
                                            new Debt {AmountOwed = 200.0m},
                                            new Debt {AmountOwed = 300.0m}
                                        }
                    };

            BuilderHelpers.SetIdUsingReflection(debtor, id);

            return debtor;
        }
    }
}
