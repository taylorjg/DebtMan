using System.ComponentModel.DataAnnotations;
using DebtMan.WebApp.App_GlobalResources;

namespace DebtMan.WebApp.Models
{
    public class DebtorEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorEditModelNameDisplayName")]
        public string Name { get; set; }

        [Required]
        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorEditModelIncomeDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Income { get; set; }

        [Required]
        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorEditModelExpenditureDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Expenditure { get; set; }

        [Required]
        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorEditModelCompanyNameDisplayName")]
        public string CompanyName { get; set; }

        public DebtEditModel[] Debts { get; set; }
    }
}
