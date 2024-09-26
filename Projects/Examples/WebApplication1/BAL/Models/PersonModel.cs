using BAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class PersonModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public RolesEnum Role { get; set; }
    }
}
