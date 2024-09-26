using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generators
{
	public class DataGenerator
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new DatabaseContext(
			serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
			{
				// Look for any board games.
				if (context.People.Any())
				{
					return;   // Data was already seeded
				}

				context.People.AddRange(
					new Models.Person
					{
						Id = 1,
						Name = "Andrii",
						Age = 24,
						Created = DateTime.Now,
						Role = Models.RolesEnum.Admin
					},
					new Models.Person
					{
						Id = 2,
						Name = "Anton",
						Age = 80,
						Created = DateTime.Now,
						Role = Models.RolesEnum.Admin
					},
					new Models.Person
					{
						Id = 3,
						Name = "Oleksii",
						Age = 44,
						Created = DateTime.Now,
						Role = Models.RolesEnum.User
					},
					new Models.Person
					{
						Id = 4,
						Name = "Someone",
						Age = 22,
						Created = DateTime.Now,
						Role = Models.RolesEnum.Moderator
					});

				context.SaveChanges();
			}

		}
	}
}
