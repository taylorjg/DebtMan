using System;

namespace DebtMan.DomainModel
{
    public class CommissionCalculatorCompanyC : CommissionCalculatorBase
    {
        private const decimal FeePerChunkOfAmountOwed = 10.0m;
        private const decimal ChunkOfAmountOwed = 1000.0m;
        private const decimal MaximumFee = 100.0m;

        public override decimal CalculateManagementFee(Debtor debtor)
        {
            var monthlyManagementFee = Math.Ceiling(debtor.TotalAmountOwed / ChunkOfAmountOwed) * FeePerChunkOfAmountOwed;

            if (monthlyManagementFee > MaximumFee) {
                monthlyManagementFee = MaximumFee;
            }

            return monthlyManagementFee;
        }
    }
}
