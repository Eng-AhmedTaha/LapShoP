using System;
using System.Collections.Generic;

namespace LapShop.Models
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            Items = new HashSet<TbItem>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;

        public virtual TbBusinessInfo TbBusinessInfo { get; set; } = null!;

        public virtual ICollection<TbItem> Items { get; set; }
    }
}
