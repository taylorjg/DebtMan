using System;

namespace DebtMan.DomainModel
{
    public class CreditorRepayment
    {
        public CreditorRepayment(Creditor creditor, decimal monthlyRepayment)
        {
            Creditor = creditor;
            MonthlyRepayment = monthlyRepayment;
        }

        public Creditor Creditor { get; private set; }
        public decimal MonthlyRepayment { get; private set; }
    }
}
