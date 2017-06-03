namespace EShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(50)]
        public string CartID { get; set; }

        public int ProductID { get; set; }

        public int Qunatity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}
