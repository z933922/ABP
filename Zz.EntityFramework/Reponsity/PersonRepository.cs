using IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zz.EntityFramework.Repositories;
using Abp.EntityFramework;
using Zz.EntityFramework;
using Zz.DTOS;

namespace Zz.Reponsity
{
    //   自己定义的 仓储 都必须继承 RepositoryBase 
    public class PersonRepository : ZzRepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IDbContextProvider<ZzDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        /// <summary>
        ///   得到莫一个 Person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public List<Person> GetPersonByid(long personId)
        {
            var query = GetAll();

            if (personId > 0)
            {
                query = query.Where(t => t.Id == personId);
            }
            return query.ToList();
        }
    }
}
