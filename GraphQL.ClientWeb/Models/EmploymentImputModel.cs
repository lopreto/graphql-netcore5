using System;

namespace GraphQL.ClientWeb.Models
{
    public class EmploymentImputModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
    }
}
