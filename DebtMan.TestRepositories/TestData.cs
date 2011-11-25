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
            var items = new List<Debtor>();
            items.Add(CreateDebtor1());
            items.Add(CreateDebtor2());
            items.Add(CreateDebtor3());
            items.Add(CreateDebtor4());
            var debtorTestRepository = new DebtorTestRepository(items);
            return debtorTestRepository;
        }

        private static Debtor CreateDebtor1()
        {
            var debtor = new Debtor();
            SetIdUsingReflection(debtor, 1);
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
            return debtor;
        }

        private static Debtor CreateDebtor2()
        {
            var debtor = new Debtor();
            SetIdUsingReflection(debtor, 2);
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
            return debtor;
        }

        private static Debtor CreateDebtor3()
        {
            var debtor = new Debtor();
            SetIdUsingReflection(debtor, 3);
            debtor.Name = "Miss T. Un-terre";
            debtor.Income = 500m;
            debtor.Expenditure = 400m;
            debtor.Company = Company.CompanyB;
            debtor.Creditors = new Creditor[] {
                new Creditor() { AmountOwed = 100m },
                new Creditor() { AmountOwed = 2400m },
                new Creditor() { AmountOwed = 5000m }
            };
            return debtor;
        }

        private static Debtor CreateDebtor4()
        {
            var debtor = new Debtor();
            SetIdUsingReflection(debtor, 4);
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
            return debtor;
        }

        private static void SetFieldUsingReflection(object target, string fieldName, object value)
        {
            FieldInfo fieldInfo = target.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

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
