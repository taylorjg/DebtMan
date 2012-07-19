using System.ComponentModel.DataAnnotations;
using DebtMan.WebApp.App_GlobalResources;

namespace DebtMan.WebApp.Models
{
    public class DebtorViewModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorViewModelNameDisplayName")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorViewModelIncomeDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Income { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorViewModelExpenditureDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Expenditure { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorViewModelDisposableIncomeDisplayName")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DisposableIncome { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorViewModelTotalAmountOwedDisplayName")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalAmountOwed { get; set; }

        [Display(ResourceType = typeof(DebtManWebAppResources), Name = "DebtorViewModelCompanyNameDisplayName")]
        public string CompanyName { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MonthlyManagementFeeCompanyA { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MonthlyManagementFeeCompanyB { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MonthlyManagementFeeCompanyC { get; set; }

        public bool IsWithCompanyA { get; set; }
        public bool IsWithCompanyB { get; set; }
        public bool IsWithCompanyC { get; set; }

        public DebtViewModel[] Debts { get; set; }
    }
}
