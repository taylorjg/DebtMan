using System;
using AutoMapper;

namespace DebtMan.WebApp
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(configuration => configuration.AddProfile<DomainModelToPresentationModelProfile>());
        }
    }
}
