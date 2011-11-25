using System;
using System.Collections.Generic;

namespace DebtMan.DomainModel
{
    public class DebtManagementPlan
    {
        private readonly CommissionCalculatorBase _commissionCalculator = null;
        private readonly List<CreditorRepayment> _creditorRepayments = new List<CreditorRepayment>();

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
            decimal remainingDisposableIncome = Debtor.DisposableIncome - MonthlyManagementFee;
            decimal totalAmountOwed = Debtor.TotalAmountOwed;

            foreach (var creditor in Debtor.Creditors) {
                decimal monthlyRepayment = creditor.AmountOwed * remainingDisposableIncome / totalAmountOwed;
                // The monthly repayment should not exceed the amount owed!
                if (monthlyRepayment > creditor.AmountOwed) {
                    monthlyRepayment = creditor.AmountOwed;
                }
                _creditorRepayments.Add(new CreditorRepayment(creditor, monthlyRepayment));
            }
        }
    }
}
