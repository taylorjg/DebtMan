using System;

namespace DebtMan.DomainModel
{
    public class CommissionCalculatorCompanyB : CommissionCalculatorBase
    {
        private const decimal MINIMUM_FEE = 25.0m;
        private const decimal MAXIMUM_FEE = 300.0m;
        private const decimal FIRST_THRESHOLD = 100.0m;
        private const decimal SECOND_THRESHOLD = 200.0m;
        private const decimal UNDER_SECOND_THRESHOLD_FEE = 30.0m;
        private const decimal OVER_SECOND_THRESHOLD_PERCENT = 16.0m;

        public override decimal CalculateManagementFee(Debtor debtor)
        {
            decimal monthlyManagementFee = 0.0m;

            if (debtor.DisposableIncome < FIRST_THRESHOLD) {
                monthlyManagementFee = MINIMUM_FEE;
            }
            else {
                if (debtor.DisposableIncome < SECOND_THRESHOLD) {
                    monthlyManagementFee = UNDER_SECOND_THRESHOLD_FEE;
                }
                else {
                    monthlyManagementFee = debtor.DisposableIncome * OVER_SECOND_THRESHOLD_PERCENT / 100;
                }
            }

            if (monthlyManagementFee < MINIMUM_FEE) {
                monthlyManagementFee = MINIMUM_FEE;
            }

            if (monthlyManagementFee > MAXIMUM_FEE) {
                monthlyManagementFee = MAXIMUM_FEE;
            }

            return monthlyManagementFee;
        }
    }
}
