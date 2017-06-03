using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Models
{
    [Table("OrderDetail")]
    public class OrderDetailTable
    {
        [Key]
        [Required]
        public int OrderDetailID { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }


        [Required]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        public int Qunatity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }


        public virtual OrderTable Order { get; set; }

        public virtual ProductTable Product { get; set; }

    }
}
