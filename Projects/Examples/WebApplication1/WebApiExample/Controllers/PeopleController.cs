using AutoMapper;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PeopleController : ControllerBase
	{
		private readonly IMapper _mapper;

		private readonly IPersonService _personService;

		public PeopleController(IMapper mapper, IPersonService personService)
		{
			_mapper = mapper;
			_personService = personService;
		}

		[HttpGet(Name = "People")]
		public IEnumerable<PersonApiModel> GetAll()
		{
			var res = _personService.GetAll().Select(x => _mapper.Map<PersonApiModel>(x));
			return res;
		}


		[HttpDelete(Name = "People")]
		public IActionResult Delete(int id)
		{
			_personService.Delete(id);
			_personService.SaveChanges();
			return Ok();
		}
	}
}
