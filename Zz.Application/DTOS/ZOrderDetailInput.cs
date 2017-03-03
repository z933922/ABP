using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zz.Enum;

namespace Zz.DTOS
{
    class ZOrderDetailInput : EntityDto
    {

         public int Nums { set; get; }

         public string Remark { set; get; }


    }

}
