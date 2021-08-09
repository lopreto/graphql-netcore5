using GraphQL.Domain.DTOs;
using GraphQL.Domain.IServices;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Threading.Tasks;

namespace GraphQL.WebApi.GraphQLConfiguration
{
    public class Mutation
    {
        public async Task<CompanyDto> CreateCompany([Service] ICompanyService companyService,
            [Service] ITopicEventSender eventSender, string name, string nif)
        {
            var newCompany = new CompanyDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                Nif = nif
            };
            var createdCompany = await companyService.CreateCompany(newCompany);

            await eventSender.SendAsync("CompanyCreated", createdCompany);

            return createdCompany;
        }

        public async Task<EmploymentDto> CreateEmployeeWithCompanyId([Service] IEmploymentService employeeService,
            string name, string email)
        {
            var newEmployee = new EmploymentDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
            };

            var createdEmployee = await employeeService.CreateEmployee(newEmployee);
            return createdEmployee;
        }

        public async Task<EmploymentDto> CreateEmployeeWithCompany([Service] IEmploymentService employeeService,
            string name, string email, string companyName, string companyNif)
        {
            var newEmployee = new EmploymentDto
            {
                Id=Guid.NewGuid(),
                Name = name,
                Email = email,
                Company = new CompanyDto {Id = Guid.NewGuid(), Name = companyName, Nif = companyNif }
            };

            var createdEmployee = await employeeService.CreateEmployee(newEmployee);
            return createdEmployee;
        }
    }
}
