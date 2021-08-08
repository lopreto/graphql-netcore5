using GraphQL.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.IRepositories
{
    public interface IEmploymentRepository
    {
        List<Employment> GetEmployees();
        Employment GetEmployeeById(Guid id);
        List<Employment> GetEmployeesWithCompany();
        Task<Employment> CreateEmployee(Employment employee);
    }
}
