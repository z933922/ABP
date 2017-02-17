using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zz.Enum;

namespace Zz.DTOS
{
    [AutoMapTo(typeof(Person))]
    public class ZPeopleInput : EntityDto
    {
        [Required]
        public int   Age { set; get; }

        [Required,MaxLength(10)]
        public  string Name { get; set; }
       
         public string DoubleName { set; get; }
    }
}
    

