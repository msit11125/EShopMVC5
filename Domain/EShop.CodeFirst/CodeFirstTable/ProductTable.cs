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
    //建置Code First使用之Product模型
    [Table("Product")]
    public class ProductTable
    {
        /// <summary>
        /// 商品流水號
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ProductID { get; set; } 

        [Required]
        [DisplayName("商品型號")]
        [StringLength(50)]
        public string ProductModel { get; set; }


        [DisplayName("商品名稱")]
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }


        [DisplayName("子分類編號")]
        [Required]
        [ForeignKey("CategorySub")]
        public int CategorySubID { get; set; }


        [DisplayName("價格")]
        [Required]
        public decimal UnitPrice { get; set; }


        /// <summary>
        /// 存圖片路徑最後的名稱，例如: car1.jpg
        /// </summary>
        [DisplayName("商品圖片")]
        public string Photo { get; set; }


        [DisplayName("商品介紹")]
        public string Description { get; set; }

        /// <summary>
        /// 1:上架   0:下架
        /// </summary>
        [DisplayName("上下架狀況")] 
        public int Status { get; set; }

        [DisplayName("建立日期")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }


        [DisplayName("最後修改日期")]
        public DateTime? ModifyDate { get; set; }


        public virtual CategorySubTable CategorySub { get; set; }

        public virtual ICollection<OrderDetailTable> OrderDetail { get; set; }

        public virtual ICollection<ShoppingCartTable> ShoppingCart { get; set; }

    }
}
