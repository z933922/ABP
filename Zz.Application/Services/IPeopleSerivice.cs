using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zz.DTOS;

namespace Zz.Services
{
   public   interface IPeopleSerivice: IApplicationService
    {
        int CreatePerson(ZPeopleInput input);
        IList<ZPeopleOutput> GetAllPeople();

        ZPeopleOutput GetOnePeople(int peopleid);
    }
}
