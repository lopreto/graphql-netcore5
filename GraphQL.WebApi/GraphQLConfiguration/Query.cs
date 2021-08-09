using GraphQL.Domain.DTOs;
using GraphQL.Domain.IServices;
using GraphQL.Infrastructure.DataAccess;
using GraphQL.Infrastructure.IRepositories;
using GraphQL.Infrastructure.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.WebApi.GraphQLConfiguration
{
    public class Query
    {
        public async Task<List<EmploymentDto>> AllEmployeeOnly([Service] IEmploymentService employeeService) =>
         await employeeService.GetEmployees();

        public async Task<List<EmploymentDto>> AllEmployeeWithCompany([Service] IEmploymentService employeeService) =>
            await employeeService.GetEmployeesWithCompany();

        public async Task<EmploymentDto> GetEmployeeById([Service] IEmploymentService employeeService,
            [Service] ITopicEventSender eventSender, Guid id)
        {
            var gottenEmployee = await employeeService.GetEmployeeById(id);
            await eventSender.SendAsync("ReturnedEmployee", gottenEmployee);
            return gottenEmployee;
        }

        public async Task<List<CompanyDto>> AllCompaniesOnly([Service] ICompanyService companyService) =>
            await companyService.GetAllCompaniesOnly();
    }
}
