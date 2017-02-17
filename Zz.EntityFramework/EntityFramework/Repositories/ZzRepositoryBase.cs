using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Zz.EntityFramework.Repositories
{
    public abstract class ZzRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ZzDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ZzRepositoryBase(IDbContextProvider<ZzDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ZzRepositoryBase<TEntity> : ZzRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ZzRepositoryBase(IDbContextProvider<ZzDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
