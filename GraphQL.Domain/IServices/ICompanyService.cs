using GraphQL.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Domain.IServices
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAllCompaniesOnly();
        Task<CompanyDto> CreateCompany(CompanyDto company);
    }
}
