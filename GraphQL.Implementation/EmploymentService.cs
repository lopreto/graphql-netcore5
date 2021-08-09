using GraphQL.Domain.DTOs;
using GraphQL.Domain.IServices;
using GraphQL.Infrastructure.DataAccess;
using GraphQL.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Implementation
{
    public class EmploymentService : BaseService, IEmploymentService
    {
        private IEmploymentRepository _employmentRepository;
        public EmploymentService(IEmploymentRepository employmentRepository)
        {
            _employmentRepository = employmentRepository;
        }

        public async Task<EmploymentDto> CreateEmployee(EmploymentDto newEmployee)
        {
            return _mapper.Map<EmploymentDto>(await _employmentRepository.CreateEmployee(_mapper.Map<Employment>(newEmployee)));
        }

        public async Task<EmploymentDto> GetEmployeeById(Guid id)
        {
            return  _mapper.Map<EmploymentDto>(await _employmentRepository.GetEmployeeById(id));
        }

        public async Task<List<EmploymentDto>> GetEmployees()
        {
            return _mapper.Map<List<EmploymentDto>>(await _employmentRepository.GetEmployees());
        }

        public async Task<List<EmploymentDto>> GetEmployeesWithCompany()
        {
            return _mapper.Map<List<EmploymentDto>>(await _employmentRepository.GetEmployeesWithCompany());
        }
    }
}
