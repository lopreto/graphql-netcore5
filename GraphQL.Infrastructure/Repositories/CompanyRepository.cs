using GraphQL.Infrastructure.DataAccess;
using GraphQL.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly GraphQLClientesContext _dbContext;

        public CompanyRepository(GraphQLClientesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Company> GetAllCompaniesOnly()
        {
            return _dbContext.Companies.ToList();
        }

        public async Task<Company> CreateCompany(Company department)
        {
            await _dbContext.Companies.AddAsync(department);
            await _dbContext.SaveChangesAsync();
            return department;
        }
    }
}
