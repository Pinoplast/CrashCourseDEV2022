using AutoMapper;
using BAL.Interfaces;
using BAL.Models;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class PersonService : IPersonService
	{
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonService(DatabaseContext databaseContext, IMapper mapper)
        {
            _context = databaseContext;
            _mapper = mapper;
		}

        public void Add(PersonModel entity)
        {
            _context.People.Add(_mapper.Map<Person>(entity));
		}

        public void Delete(int id)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == id);
            _context.Remove(person);
		}

        public IEnumerable<PersonModel> GetAll()
        {
            var res = _context.People.Select(x => _mapper.Map<PersonModel>(x)).ToList();
            return res;
        }

        public PersonModel GetById(int id)
        {
            return _mapper.Map<PersonModel>(_context.People.FirstOrDefault(x => x.Id == id));

		}

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(PersonModel entity)
        {
			var person = _context.People.FirstOrDefault(x => x.Id == entity.Id);
			_context.Update(person);
		}
    }
}
