using AutoMapper;
using DebtMan.WebApp.Mappers;

namespace DebtMan.WebApp.Bootstrappers
{
    public class AutoMapperBootstrapper
    {
        public static void Configure()
        {
            Mapper.Initialize(configuration => configuration.AddProfile<DebtManAutoMapperProfile>());
        }
    }
}
