namespace DebtMan.DomainModel
{
    public class CommissionCalculatorCompanyB : CommissionCalculatorBase
    {
        private const decimal MinimumFee = 25.0m;
        private const decimal MaximumFee = 300.0m;
        private const decimal FirstThreshold = 100.0m;
        private const decimal SecondThreshold = 200.0m;
        private const decimal UnderSecondThresholdFee = 30.0m;
        private const decimal OverSecondThresholdPercent = 16.0m;

        public override decimal CalculateManagementFee(Debtor debtor)
        {
            decimal monthlyManagementFee;

            if (debtor.DisposableIncome < FirstThreshold) {
                monthlyManagementFee = MinimumFee;
            }
            else {
                if (debtor.DisposableIncome < SecondThreshold) {
                    monthlyManagementFee = UnderSecondThresholdFee;
                }
                else {
                    monthlyManagementFee = debtor.DisposableIncome * OverSecondThresholdPercent / 100;
                }
            }

            if (monthlyManagementFee < MinimumFee) {
                monthlyManagementFee = MinimumFee;
            }

            if (monthlyManagementFee > MaximumFee) {
                monthlyManagementFee = MaximumFee;
            }

            return monthlyManagementFee;
        }
    }
}
