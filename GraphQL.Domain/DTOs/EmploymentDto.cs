using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Domain.DTOs
{
    public class EmploymentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }

        public virtual CompanyDto Company { get; set; }
    }
}
