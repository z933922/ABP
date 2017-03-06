using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
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
    public class PeopleSerivice : IPeopleSerivice
    {
        private readonly IRepository<Person> _personRepository;

        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public PeopleSerivice(IRepository<Person> personRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _personRepository = personRepository;
            unitOfWorkManager = _unitOfWorkManager;
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


        [UnitOfWork(IsDisabled = false)]
       
        public IList<ZPeopleOutput> GetAllPeople()
        {
            var list = _personRepository.GetAll().ToList();
            var tt = AutoMapper.Mapper.Map< List<ZPeopleOutput>>(list);

            //IList<ZPeopleOutput> tt = new List<ZPeopleOutput>();

            //foreach (Person item in list)
            //{
            //    var ZPeopleOutput = AutoMapper.Mapper.Map<ZPeopleOutput>(item);

            //    tt.Add(ZPeopleOutput);
            //}

           // [UnitOfWork(IsDisabled = false)]
           //    这个下面的操作是一样的， 在同一个工作单元中，就是在同一个事务中。 只是不同的写法，
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                //  数据库的操作

                unitOfWork.Complete();
            }
            return tt;
        }
        public ZPeopleOutput GetOnePeople(int peopleid)
        {
            var person = _personRepository.Get(peopleid);
            ZPeopleOutput model = Mapper.Map<ZPeopleOutput>(person);
            return model;
        }



    }

    public static class Ext
    {
        public static List<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            return Mapper.Map<List<TDestination>>(source);
        }

    }
}
