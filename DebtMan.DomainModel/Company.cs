using System.ComponentModel.DataAnnotations;

namespace DebtMan.DomainModel
{
    public enum Company {

        [Display(ResourceType = typeof(DebtManResources), Name = "CompanyADisplayName")]
        CompanyA,

        [Display(ResourceType = typeof(DebtManResources), Name = "CompanyBDisplayName")]
        CompanyB,

        [Display(ResourceType = typeof(DebtManResources), Name = "CompanyCDisplayName")]
        CompanyC,
    };
}
