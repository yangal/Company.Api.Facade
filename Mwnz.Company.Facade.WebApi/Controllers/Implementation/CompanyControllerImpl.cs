using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mwnz.Company.Facade.WebApi.Controllers.Specification;
using Mwnz.Company.Facade.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwnz.Company.Facade.WebApi.Controllers.Implementation
{
    public class CompanyControllerImpl : ICompanyController
    {
        private readonly ILogger<CompanyControllerImpl> _logger;
        private readonly ICompanyService _companyService;

        public CompanyControllerImpl(ILogger<CompanyControllerImpl> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<Specification.Company>> CompaniesAsync(double id)
        {
            return await _companyService.GetCompany(id);
        }

    }
}
