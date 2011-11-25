using System;
using System.ComponentModel.DataAnnotations; 

namespace DebtMan.WebApp.Models
{
    public class CreditorModel
    {
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal AmountOwed { get; set; }
    }

    public class DebtorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Income { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Expenditure { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal DisposableIncome { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal TotalAmountOwed { get; set; }

        public string CompanyName { get; set; }
        public string MonthlyManagementFeeCompanyA { get; set; }
        public string MonthlyManagementFeeCompanyB { get; set; }
        public string MonthlyManagementFeeCompanyC { get; set; }

        public CreditorModel[] Creditors { get; set; }
    }
}
