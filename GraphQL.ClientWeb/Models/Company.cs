using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.ClientWeb.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
    }
    public class ResponseCompanyCollection
    {
        public List<Company> Companies { get; set; }
    }

    public class ResponseCompany
    {
        public Company Company{ get; set; }
    }
}
