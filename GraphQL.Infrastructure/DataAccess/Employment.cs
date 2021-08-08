using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL.Infrastructure.DataAccess
{
    public class Employment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
