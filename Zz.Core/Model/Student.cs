using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class Student : Entity
    {

        public  virtual int Age { set; get; }
        public virtual string Name { get; set; }

       
    }
}
