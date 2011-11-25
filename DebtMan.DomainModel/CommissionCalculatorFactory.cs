using System;

namespace DebtMan.DomainModel
{
    internal static class CommissionCalculatorFactory
    {
        public static CommissionCalculatorBase GetCommissionCalculator(Company company)
        {
            CommissionCalculatorBase commissionCalculatorBase = null;

            switch (company) {

                case Company.CompanyA:
                    commissionCalculatorBase = new CommissionCalculatorCompanyA();
                    break;

                case Company.CompanyB:
                    commissionCalculatorBase = new CommissionCalculatorCompanyB();
                    break;

                case Company.CompanyC:
                    commissionCalculatorBase = new CommissionCalculatorCompanyC();
                    break;

                default:
                    throw new InvalidOperationException("Unknown company!");
            }

            return commissionCalculatorBase;
        }
    }
}
