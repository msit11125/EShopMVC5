using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Models
{
    [Table("Order")]
    public class OrderTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OrderID { get; set; } //流水號


        [Required]
        [ForeignKey("Account")]
        public int UserID { get; set; }

        [Required]
        public string RecievedAddress { get; set; }

        /// <summary>
        /// 訂購日期
        /// </summary>
        [Required]
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// 交貨日期
        /// </summary>
        [Required]
        public DateTime ShipDate { get; set; }

        




        public virtual AccountTable Account { get; set; }

        public virtual ICollection<OrderDetailTable> Product { get; set; }

    }
}
