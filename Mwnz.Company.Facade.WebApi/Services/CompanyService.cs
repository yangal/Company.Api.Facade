using AutoMapper;
using Microsoft.Extensions.Logging;
using Mwnz.Company.Source.Xml.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mwnz.Company.Facade.WebApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IClient _client;
        private readonly ILogger<ICompanyService> _logger;
        private readonly IMapper _mapper;

        public CompanyService(IClient client, ILogger<ICompanyService> logger, IMapper mapper)
        {
            _client = client;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Controllers.Specification.Company> GetCompany(double id)
        {
            _logger.LogInformation($"Getting company details with id '{id}'...");
            XmlCompany xmlCompany = await _client.XmlApiAsync(id);
            Controllers.Specification.Company company = _mapper.Map<XmlCompany, Controllers.Specification.Company>(xmlCompany);
            _logger.LogInformation($"Found company - '{company}'");
            return company;
        }
    }
}
