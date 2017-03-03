using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    ///   order 的明细表
    /// </summary>
    public class OrderDetail : Entity 
    {
        /// <summary>
        ///  数量
        /// </summary>
        public  virtual   int Nums { set; get; }

        /// <summary>
        ///  订单备注
        /// </summary>
        [MaxLength(1000)]
      public virtual    string Remark { set; get; }

    }
}
