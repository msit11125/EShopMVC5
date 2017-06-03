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
    [Table("Category")]
    public class CategoryTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CategoryID { get; set; } //主類別流水號


        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }




        public virtual ICollection<CategorySubTable> CategorySub { get; set; }

    }
}
