using System.Collections.Generic;

namespace DebtMan.DomainModel
{
    public class DebtManagementPlan
    {
        private readonly CommissionCalculatorBase _commissionCalculator;
        private readonly IList<CreditorRepayment> _creditorRepayments = new List<CreditorRepayment>();

        public DebtManagementPlan(Debtor debtor) : this(debtor, debtor.Company)
        {
        }

        public DebtManagementPlan(Debtor debtor, Company company)
        {
            Debtor = debtor;
            Company = company;

            _commissionCalculator = CommissionCalculatorFactory.GetCommissionCalculator(Company);

            MonthlyManagementFee = _commissionCalculator.CalculateManagementFee(Debtor);

            CalculateProRataRepaymentsToCreditors();
        }

        public Debtor Debtor { get; private set; }
        public Company Company { get; private set; }
        public decimal MonthlyManagementFee { get; private set; }
        public IEnumerable<CreditorRepayment> CreditorRepayments { get { return _creditorRepayments; } }

        protected void CalculateProRataRepaymentsToCreditors()
        {
            var remainingDisposableIncome = Debtor.DisposableIncome - MonthlyManagementFee;
            var totalAmountOwed = Debtor.TotalAmountOwed;

            if (totalAmountOwed <= 0) return;

            foreach (var debt in Debtor.Debts) {
                var monthlyRepayment = debt.AmountOwed * remainingDisposableIncome / totalAmountOwed;
                // The monthly repayment should not exceed the amount owed!
                if (monthlyRepayment > debt.AmountOwed) {
                    monthlyRepayment = debt.AmountOwed;
                }
                _creditorRepayments.Add(new CreditorRepayment(debt, monthlyRepayment));
            }
        }
    }
}
