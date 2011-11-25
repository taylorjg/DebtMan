using System;
using System.Collections.Generic;
using AutoMapper;
using DebtMan.DomainModel;
using DebtMan.WebApp.Models;

namespace DebtMan.WebApp
{
    public class DomainModelToPresentationModelProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainModelToPresentationModelProfile";
            }
        }

        protected override void Configure()
        {
            CreateMap<Debtor, DebtorModel>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => CompanyToString(src.Company)))
                .ForMember(dest => dest.MonthlyManagementFeeCompanyA, opt => opt.MapFrom(src => GetMonthlyManagementFee(src, Company.CompanyA)))
                .ForMember(dest => dest.MonthlyManagementFeeCompanyB, opt => opt.MapFrom(src => GetMonthlyManagementFee(src, Company.CompanyB)))
                .ForMember(dest => dest.MonthlyManagementFeeCompanyC, opt => opt.MapFrom(src => GetMonthlyManagementFee(src, Company.CompanyC)));

            CreateMap<Creditor, CreditorModel>();

            CreateMap<DebtManagementPlan, DebtManagementPlanModel>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => CompanyToString(src.Company)))
                .ForMember(dest => dest.CreditorDetails, opt => opt.ResolveUsing<CreditorDetailsResolver>());

            CreateMap<CreditorRepayment, CreditorDetailsModel>();
        }

        private string CompanyToString(Company company)
        {
            string companyName = string.Empty;

            switch (company) {
                case Company.CompanyA:
                    companyName = "McDermott and Godfrey";
                    break;
                case Company.CompanyB:
                    companyName = "DebtDestructor";
                    break;
                case Company.CompanyC:
                    companyName = "MoneyHelper";
                    break;
            }

            return companyName;
        }

        private string GetMonthlyManagementFee(Debtor debtor, Company company)
        {
            string result = string.Empty;

            var dmp = new DebtManagementPlan(debtor, company);
            string monthlyManagementFee = dmp.MonthlyManagementFee.ToString("C");

            if (debtor.Company == company) {
                result = string.Format("*** {0} ***", monthlyManagementFee);
            }
            else {
                result = monthlyManagementFee;
            }

            return result;
        }

        private class CreditorDetailsResolver : ValueResolver<DebtManagementPlan, CreditorDetailsModel[]>
        {
            protected override CreditorDetailsModel[] ResolveCore(DebtManagementPlan dmp)
            {
                return Mapper.Map<IEnumerable<CreditorRepayment>, CreditorDetailsModel[]>(dmp.CreditorRepayments);
            }
        }
    }
}
