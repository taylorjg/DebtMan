using System;
using System.ComponentModel.DataAnnotations; 

namespace DebtMan.WebApp.Models
{
    public class CreditorDetailsModel
    {
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal CreditorAmountOwed { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal MonthlyRepayment { get; set; }
    }

    public class DebtManagementPlanModel
    {
        public int DebtorId { get; set; }
        public string DebtorName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal DebtorIncome { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal DebtorExpenditure { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal DebtorDisposableIncome { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal DebtorTotalAmountOwed { get; set; }

        public string CompanyName { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal MonthlyManagementFee { get; set; }

        public CreditorDetailsModel[] CreditorDetails { get; set; }
    }
}
