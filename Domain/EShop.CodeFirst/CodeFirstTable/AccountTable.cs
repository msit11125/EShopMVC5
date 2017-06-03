using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Models
{
    [Table("Account")]
    public class AccountTable
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserID { get; set; } //流水號

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$")] //密碼長度6，英數字再加上包含大小寫
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        /// <summary>
        /// 存圖片路徑最後的名稱，例如: car1.jpg
        /// </summary>
        public string Photo { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// 目前擁有的電子貨幣
        /// </summary>
        [Required]
        public decimal Cash { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ICollection<OrderTable> Order { get; set; }




    }
}
