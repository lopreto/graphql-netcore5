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

        public List<Employment> GetEmployees()
        {
            return _dbContext.Employments.ToList();
        }

        public Employment GetEmployeeById(Guid id)
        {
            var employee = _dbContext.Employments
                .Include(e => e.Company)
                .Where(e => e.Id == id)
                .FirstOrDefault();

            if (employee != null)
                return employee;

            return null;
        }

        public List<Employment> GetEmployeesWithCompany()
        {
            return _dbContext.Employments
                .Include(e => e.Company)
                .ToList();
        }

        public async Task<Employment> CreateEmployee(Employment employee)
        {
            await _dbContext.Employments.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
