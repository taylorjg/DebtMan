using System;

namespace DebtMan.DomainModel
{
    public class CommissionCalculatorCompanyA : CommissionCalculatorBase
    {
        private const decimal FEE_PERCENT = 15.0m;

        public override decimal CalculateManagementFee(Debtor debtor)
        {
            decimal monthlyManagementFee = debtor.DisposableIncome * FEE_PERCENT / 100;
            return monthlyManagementFee;
        }
    }
}
