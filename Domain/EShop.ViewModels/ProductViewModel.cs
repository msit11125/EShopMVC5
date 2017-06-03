using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        [Display(Name = "商品型號")]
        [Required]
        [StringLength(50)]
        public string ProductModel { get; set; }

        [Display(Name = "商品名稱")]
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Display(Name = "子分類編號")]
        public int CategorySubID { get; set; }

        [Display(Name = "商品單價")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 照片路徑
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string Photo { get; set; }

        [Display(Name = "商品描述")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "上下架狀態")]
        public int Status { get; set; }

        [Display(AutoGenerateField = false)]
        public DateTime? CreateDate { get; set; }

        [Display(AutoGenerateField = false)]
        public DateTime? ModifyDate { get; set; }

        public CategorySubViewModel CategorySub { get; set; }
    }
}
