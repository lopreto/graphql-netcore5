using GraphQL.Infrastructure.DataAccess;
using GraphQL.Infrastructure.IRepositories;
using GraphQL.Infrastructure.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.GraphQLQuery
{
    public class Query
    {


        public List<Employment> AllEmployeeOnly([Service] IEmploymentRepository employeeRepository) =>
            employeeRepository.GetEmployees();

        public List<Employment> AllEmployeeWithCompany([Service] IEmploymentRepository employeeRepository) =>
            employeeRepository.GetEmployeesWithCompany();

        public async Task<Employment> GetEmployeeById([Service] IEmploymentRepository employeeRepository,
            [Service] ITopicEventSender eventSender, Guid id)
        {
            var gottenEmployee = employeeRepository.GetEmployeeById(id);
            await eventSender.SendAsync("ReturnedEmployee", gottenEmployee);
            return gottenEmployee;
        }

        public List<Company> AllCompaniesOnly([Service] ICompanyRepository companyRepository) =>
            companyRepository.GetAllCompaniesOnly();

        //public List<Company> AllDepartmentsWithEmployee([Service] CompanyRepository companyRepository) =>
        //    companyRepository.Geta();
    }
}
