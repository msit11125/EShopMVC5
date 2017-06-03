namespace EShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CategorySub")]
    public partial class CategorySub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategorySub()
        {
            Products = new HashSet<Product>();
        }

        public int CategorySubID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryNameSub { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
