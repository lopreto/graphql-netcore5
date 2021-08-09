using GraphQL.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.IRepositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompaniesOnly();
        Task<Company> CreateCompany(Company department);
    }
}
