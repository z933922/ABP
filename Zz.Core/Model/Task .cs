using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Localization;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zz.Enum;

namespace Model
{
   public  class ZTask :FullAuditedEntity
    {

            [ForeignKey("AssignedPersonId")]
            public virtual Person AssignedPerson { get; set; }

            public virtual int? AssignedPersonId { get; set; }

            public virtual string Description { get; set; }

         //   public  virtual DateTime CreationTime { get; set; }

            public virtual TaskState State { get; set; }

            public ZTask()
            {
                CreationTime = DateTime.Now;
                State = TaskState.Active;
            //Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            }
        
    }
}
