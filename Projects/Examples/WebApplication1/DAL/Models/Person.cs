using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public DateTime Created { get; set; }
		public RolesEnum? Role { get; set; }
	}
}
