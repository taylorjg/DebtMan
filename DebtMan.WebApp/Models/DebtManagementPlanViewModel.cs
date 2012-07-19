using System.ComponentModel.DataAnnotations;
using DebtMan.WebApp.App_GlobalResources;

namespace DebtMan.WebApp.Models
{
    public class DebtManagementPlanViewModel
    {
        public int DebtorId { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DMPViewModelDebtorNameDisplayName")]
        public string DebtorName { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DMPViewModelCompanyNameDisplayName")]
        public string CompanyName { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DMPViewModelDebtorIncomeDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DebtorIncome { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DMPViewModelDebtorExpenditureDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DebtorExpenditure { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DMPViewModelDebtorDisposableIncomeDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DebtorDisposableIncome { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DMPViewModelDebtorTotalAmountOwedDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DebtorTotalAmountOwed { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DMPViewModelMonthlyManagementFeeDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MonthlyManagementFee { get; set; }

        public CreditorRepaymentViewModel[] CreditorRepayments { get; set; }
    }
}
