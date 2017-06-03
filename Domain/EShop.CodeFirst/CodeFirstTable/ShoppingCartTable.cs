using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Models
{
    [Table("ShoppingCart")]
    public class ShoppingCartTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RecordID { get; set; } //流水號

        [StringLength(50)]
        public string CartID { get; set; } //Guid編號

        [Required]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        public int Qunatity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }


        public virtual ProductTable Product { get; set; }
    }
}
