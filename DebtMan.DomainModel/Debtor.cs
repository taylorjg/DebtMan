using System.Collections.Generic;
using System.Linq;

namespace DebtMan.DomainModel
{
    public class Debtor
    {
#pragma warning disable 649
        private int id;
#pragma warning restore 649

        public Debtor()
        {
        }

        public Debtor(int id)
        {
            this.id = id;
        }

        public int Id { get { return id; } }
        public string Name { get; set; }
        public decimal Income { get; set; }
        public decimal Expenditure { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Debt> Debts { get; set; }

        public decimal DisposableIncome
        {
            get
            {
                return Income - Expenditure;
            }
        }

        public decimal TotalAmountOwed
        {
            get
            {
                return Debts.Sum(debt => debt.AmountOwed);
            }
        }
    }
}
