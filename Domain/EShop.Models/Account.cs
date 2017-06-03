namespace EShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //這裡產生都是由DataBase First
    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public decimal Cash { get; set; }

        public DateTime CreateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
