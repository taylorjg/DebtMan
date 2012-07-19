using System.ComponentModel.DataAnnotations;
using DebtMan.WebApp.App_GlobalResources;

namespace DebtMan.WebApp.Models
{
    public class CreditorRepaymentViewModel
    {
        [DataType(DataType.Currency)]
        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "CreditorRepaymentViewModelAmountOwedDisplayName")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal AmountOwed { get; set; }

        [DataType(DataType.Currency)]
        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "CreditorRepaymentViewModelMonthlyRepaymentDisplayName")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal MonthlyRepayment { get; set; }
    }
}
