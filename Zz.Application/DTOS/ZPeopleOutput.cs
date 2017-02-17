using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zz.DTOS
{
    [AutoMapTo(typeof(Person))]
    public  class ZPeopleOutput: EntityDto
    {
        public int Age { set; get; }
        public string Name { get; set; }
        public string DoubleName { set; get; }
    }
}
