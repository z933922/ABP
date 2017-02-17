using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zz.DTOS;

namespace Zz.Services
{
   public   class PeopleSerivice: IPeopleSerivice
    {
        private readonly IRepository<Person> _personRepository;
        public PeopleSerivice(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public int CreatePerson(ZPeopleInput input)
        {
            //Creating a new Task entity with given input's properties
            var person = AutoMapper.Mapper.Map<Person>(input);
            //var person = new Person()
            //{
            //   Age=input.Age,
            //   Name=input.Name
            //};
            //Saving entity with standard Insert method of repositories.
            return _personRepository.InsertAndGetId(person);
        }

        public  IList<ZPeopleOutput> GetAllPeople()
        {
            var list = _personRepository.GetAll().ToList();
            var tt = AutoMapper.Mapper.Map<List<Person>, List<ZPeopleOutput>>(list);
            return tt;
        }
      public   ZPeopleOutput GetOnePeople(int peopleid) 
        {
            var person = _personRepository.Get(peopleid);
            ZPeopleOutput model = Mapper.Map<ZPeopleOutput>(person);
            return model;
        }

    }
}
