using GraphQL.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Domain.IServices
{
    public interface IEmploymentService
    {
        Task<List<EmploymentDto>> GetEmployees();
        Task<List<EmploymentDto>> GetEmployeesWithCompany();
        Task<EmploymentDto> GetEmployeeById(Guid id);
        Task<EmploymentDto> CreateEmployee(EmploymentDto newEmployee);
    }
}
