using GraphQL.Infrastructure.DataAccess;
using GraphQL.Infrastructure.IRepositories;
using GraphQL.Infrastructure.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.GraphQLQuery
{
    public class Mutation
    {
        public async Task<Company> CreateCompany([Service] ICompanyRepository companyRepository,
            [Service] ITopicEventSender eventSender, string name, string nif)
        {
            var newCompany = new Company
            {
                Id = Guid.NewGuid(),
                Name = name,
                Nif = nif
            };
            var createdCompany = await companyRepository.CreateCompany(newCompany);

            await eventSender.SendAsync("CompanyCreated", createdCompany);

            return createdCompany;
        }

        public async Task<Employment> CreateEmployeeWithCompanyId([Service] IEmploymentRepository employeeRepository,
            string name, string email)
        {
            Employment newEmployee = new Employment
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }

        public async Task<Employment> CreateEmployeeWithCompany([Service] IEmploymentRepository employeeRepository,
            string name, string email, string companyName, string companyNif)
        {
            Employment newEmployee = new Employment
            {
                Id=Guid.NewGuid(),
                Name = name,
                Email = email,
                Company = new Company {Id = Guid.NewGuid(), Name = companyName, Nif = companyNif }
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }
    }
}
