using GraphQL.ClientWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.ClientWeb.Models
{
    public class EmploymentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
