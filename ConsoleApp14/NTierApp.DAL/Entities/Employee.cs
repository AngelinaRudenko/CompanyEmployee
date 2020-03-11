using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.DAL.Entities
{
    public class Employee
    {
        public Employee()
        {
            Companies = new List<Company>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public ICollection<Company> Companies { get; set; }
        
    }
}
