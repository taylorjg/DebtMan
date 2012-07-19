namespace DebtMan.DomainModel
{
    public class CommissionCalculatorCompanyA : CommissionCalculatorBase
    {
        private const decimal FeePercent = 15.0m;

        public override decimal CalculateManagementFee(Debtor debtor)
        {
            return debtor.DisposableIncome * FeePercent / 100;
        }
    }
}
