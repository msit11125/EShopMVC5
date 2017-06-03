using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Models
{
    [Table("CategorySub")]
    public class CategorySubTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CategorySubID { get; set; } //子類別流水號

        [Required]
        [ForeignKey("Category")]
        public int CategoryID { get; set; } //主類別

        [Required]
        [StringLength(50)]
        public string CategoryNameSub { get; set; }


        [Required]
        [StringLength(200)]
        public string Description { get; set; }


        public virtual CategoryTable Category { get; set; }

        public virtual ICollection<ProductTable> Product { get; set; }

    }
}
