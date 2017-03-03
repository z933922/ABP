using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    ///   AuditedEntity 实体包括了 添加 修改   FullAuditedEntity AuditedEntity  创建，修改和删除
    /// </summary>
    public class Order : FullAuditedEntity 
    {
        [ForeignKey("OrderDetailId")]
        public virtual OrderDetail ModelOrderDetail { get; set; }

        public virtual int? OrderDetailId { get; set;}

    }
}
