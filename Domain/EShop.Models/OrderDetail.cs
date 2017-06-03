namespace EShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Qunatity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
