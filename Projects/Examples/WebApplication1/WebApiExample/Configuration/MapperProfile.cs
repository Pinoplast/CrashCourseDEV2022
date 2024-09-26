using AutoMapper;
using BAL.Models;
using DAL.Models;
using System.Data;
using WebApiExample.Models;

namespace WebApiExample.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
			CreateMap<PersonApiModel, PersonModel>()
				.ForMember(x => x.Role, y => y.MapFrom(z => GetRole(z.Role)));


			CreateMap<PersonModel, PersonApiModel>()
				.ForMember(x => x.Role, y => y.MapFrom(z => (int)z.Role));

						CreateMap<PersonModel, Person>().ReverseMap();
		}

        public static int GetRole(string role)
        {
			int result = int.MinValue;
			switch (role)
			{
				case "Administrator":
					result = 0;
					break;
				case "Moderator":
					result = 1;
					break;
				case "User":
					result = 2;
					break;
			}
			return result;
        }

		//public static string GetRole(int role)
		//{
		//	string result = "";
		//	switch (role)
		//	{
		//		case 0:
		//			result = "Administrator";
		//			break;
		//		case 1:
		//			result = "Moderator";
		//			break;
		//		case 2:
		//			result = "User";
		//			break;
		//	}
		//	return result;
		//}
	}
}
