using GraphQL.Domain.DTOs;
using GraphQL.Domain.IServices;
using GraphQL.Infrastructure.DataAccess;
using GraphQL.Infrastructure.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Implementation
{
    public class CompanyService : BaseService, ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<List<CompanyDto>> GetAllCompaniesOnly()
        {
            return _mapper.Map<List<CompanyDto>>(await _companyRepository.GetAllCompaniesOnly());
        }

        public async Task<CompanyDto> CreateCompany(CompanyDto company)
        {
            return _mapper.Map<CompanyDto>(await _companyRepository.CreateCompany(_mapper.Map<Company>(company)));
        }
    }
}
