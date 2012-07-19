using System.ComponentModel.DataAnnotations;
using DebtMan.WebApp.App_GlobalResources;

namespace DebtMan.WebApp.Models
{
    public class DebtViewModel
    {
        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtViewModelAmountOwedDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal AmountOwed { get; set; }
    }
}
