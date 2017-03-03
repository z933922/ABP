using System.Data.Common;
using Abp.Zero.EntityFramework;
using Zz.Authorization.Roles;
using Zz.MultiTenancy;
using Zz.Users;
using System.Data.Entity;
using Model;

namespace Zz.EntityFramework
{
    public class ZzDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<ZTask> Tasks { get; set; }

        public virtual IDbSet<Person> People { get; set; }


        public virtual IDbSet<Order> Order { get; set; }

        public virtual IDbSet<OrderDetail> OrderDetail { get; set; }



        //public virtual DbSet<DTOS.ZPeopleInput> ZPeopleInputs { get; set; }

        //public virtual DbSet<DTOS.ZPeopleOutput> ZPeopleOutputs { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ZzDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ZzDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ZzDbContext since ABP automatically handles it.
         */
        public ZzDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ZzDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

    }
}
