using GraphQL.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.IRepositories
{
    public interface IEmploymentRepository
    {
        Task<List<Employment>> GetEmployees();
        Task<Employment> GetEmployeeById(Guid id);
        Task<List<Employment>> GetEmployeesWithCompany();
        Task<Employment> CreateEmployee(Employment employee);
    }
}
