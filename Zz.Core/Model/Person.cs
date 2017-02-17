using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class Person:Entity
    {

        public  virtual int Age { set; get; }
        public virtual string Name { get; set; }
    }
}
