using GraphQL.Infrastructure.DataAccess;
using GraphQL.Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.Repositories
{
    public class EmploymentRepository : IEmploymentRepository
    {
        private readonly GraphQLClientesContext _dbContext;

        public EmploymentRepository(GraphQLClientesContext sampleAppDbContext)
        {
            _dbContext = sampleAppDbContext;
        }

        public async Task<List<Employment>> GetEmployees()
        {
            return await _dbContext.Employments.ToListAsync();
        }

        public async Task<Employment> GetEmployeeById(Guid id)
        {
            var employee = await _dbContext.Employments
                .Include(e => e.Company)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (employee != null)
                return employee;

            return null;
        }

        public async Task<List<Employment>> GetEmployeesWithCompany()
        {
            return await _dbContext.Employments
                .Include(e => e.Company)
                .ToListAsync();
        }

        public async Task<Employment> CreateEmployee(Employment employee)
        {
            await _dbContext.Employments.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
