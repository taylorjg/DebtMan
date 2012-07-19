using System.Collections.Generic;
using DebtMan.DomainModel;
using DebtMan.WebApp.Models;
using AutoMapper;

namespace DebtMan.WebApp.Mappers
{
    public class DebtManAutoMapperProfile : Profile
    {
        public override string ProfileName { get { return "DebtManAutoMapperProfile"; } }

        protected override void Configure()
        {
            CreateDomainModelToViewModelMaps();
            CreateDomainModelToEditModelMaps();
            CreateViewModelToDomainModelMaps();
            CreateEditModelToDomainModelMaps();
        }

        private void CreateDomainModelToViewModelMaps()
        {
            CreateMap<Debtor, DebtorViewModel>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyToDisplayName()))
                .ForMember(dest => dest.MonthlyManagementFeeCompanyA, opt => opt.MapFrom(src => GetMonthlyManagementFee(src, Company.CompanyA)))
                .ForMember(dest => dest.MonthlyManagementFeeCompanyB, opt => opt.MapFrom(src => GetMonthlyManagementFee(src, Company.CompanyB)))
                .ForMember(dest => dest.MonthlyManagementFeeCompanyC, opt => opt.MapFrom(src => GetMonthlyManagementFee(src, Company.CompanyC)))
                .ForMember(dest => dest.IsWithCompanyA, opt => opt.MapFrom(src => src.Company == Company.CompanyA))
                .ForMember(dest => dest.IsWithCompanyB, opt => opt.MapFrom(src => src.Company == Company.CompanyB))
                .ForMember(dest => dest.IsWithCompanyC, opt => opt.MapFrom(src => src.Company == Company.CompanyC));

            CreateMap<Debt, DebtViewModel>();

            CreateMap<DebtManagementPlan, DebtManagementPlanViewModel>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyToDisplayName()))
                .ForMember(dest => dest.CreditorRepayments, opt => opt.ResolveUsing<CreditorDetailsResolver>());

            CreateMap<CreditorRepayment, CreditorRepaymentViewModel>()
                .ForMember(dest => dest.AmountOwed, opt => opt.MapFrom(src => src.Debt.AmountOwed));
        }

        private void CreateViewModelToDomainModelMaps()
        {
            CreateMap<DebtorViewModel, Debtor>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.CompanyName.DisplayNameToCompany()));

            CreateMap<DebtViewModel, Debt>();
        }

        private void CreateDomainModelToEditModelMaps()
        {
            CreateMap<Debtor, DebtorEditModel>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyToDisplayName()));

            CreateMap<Debt, DebtEditModel>();
        }

        private void CreateEditModelToDomainModelMaps()
        {
            CreateMap<DebtorEditModel, Debtor>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.CompanyName.DisplayNameToCompany()));

            CreateMap<DebtEditModel, Debt>();
        }

        private static decimal GetMonthlyManagementFee(Debtor debtor, Company company)
        {
            return new DebtManagementPlan(debtor, company).MonthlyManagementFee;
        }

        // ReSharper disable ClassNeverInstantiated.Local
        private class CreditorDetailsResolver : ValueResolver<DebtManagementPlan, CreditorRepaymentViewModel[]>
        {
            protected override CreditorRepaymentViewModel[] ResolveCore(DebtManagementPlan dmp)
            {
                return Mapper.Map<IEnumerable<CreditorRepayment>, CreditorRepaymentViewModel[]>(dmp.CreditorRepayments);
            }
        }
        // ReSharper restore ClassNeverInstantiated.Local
    }
}
