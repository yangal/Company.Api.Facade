using AutoMapper;
using Mwnz.Company.Source.Xml.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwnz.Company.Facade.WebApi.Profiles
{
    public class CompanyMappingProfiles : Profile
    {
        public CompanyMappingProfiles()
        {
            CreateMap<XmlCompany, Controllers.Specification.Company>();
        }
    }
}
