using System.ComponentModel.DataAnnotations;
using DebtMan.WebApp.App_GlobalResources;

namespace DebtMan.WebApp.Models
{
    public class DebtEditModel
    {
        [Required]
        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtEditModelAmountOwedDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal AmountOwed { get; set; }
    }
}
