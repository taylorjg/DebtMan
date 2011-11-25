using System;

namespace DebtMan.DomainModel
{
    public class CommissionCalculatorCompanyC : CommissionCalculatorBase
    {
        private const decimal FEE_PER_CHUNK_OF_AMOUNT_OWED = 10.0m;
        private const decimal CHUNK_OF_AMOUNT_OWED = 1000.0m;
        private const decimal MAXIMUM_FEE = 100.0m;

        public override decimal CalculateManagementFee(Debtor debtor)
        {
            decimal monthlyManagementFee = Math.Ceiling(debtor.TotalAmountOwed / CHUNK_OF_AMOUNT_OWED) * FEE_PER_CHUNK_OF_AMOUNT_OWED;

            if (monthlyManagementFee > MAXIMUM_FEE) {
                monthlyManagementFee = MAXIMUM_FEE;
            }

            return monthlyManagementFee;
        }
    }
}
