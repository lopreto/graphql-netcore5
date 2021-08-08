using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL.Infrastructure.DataAccess
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
    }
}
