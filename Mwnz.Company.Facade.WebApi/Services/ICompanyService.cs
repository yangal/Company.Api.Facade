using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwnz.Company.Facade.WebApi.Services
{
    public interface ICompanyService
    {
        Task<Controllers.Specification.Company> GetCompany(double id);
    }
}
