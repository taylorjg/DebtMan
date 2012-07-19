namespace DebtMan.DomainModel
{
    public class CreditorRepayment
    {
        public CreditorRepayment(Debt debt, decimal monthlyRepayment)
        {
            Debt = debt;
            MonthlyRepayment = monthlyRepayment;
        }

        public Debt Debt { get; private set; }
        public decimal MonthlyRepayment { get; private set; }
    }
}
