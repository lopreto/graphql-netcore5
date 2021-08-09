using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Domain.DTOs
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
    }
}
