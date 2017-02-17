using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using Zz;
using Zz.EntityFramework;
using Zz.EntityFramework.Repositories;
using Model;
using IRepository;

namespace Reponsity
{
    public class ZTaskRepository : ZzRepositoryBase<ZTask>, IZTaskRepository
    {
       // 子类 
        public ZTaskRepository(IDbContextProvider<ZzDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public List<ZTask> GetPersonByAssignedPersonId(long personId)
        {
            var query = GetAll();

            if (personId > 0)
            {
                query = query.Where(t => t.AssignedPersonId == personId);
            }
            return query.ToList();
        }
    }
}
