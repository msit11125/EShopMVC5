using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels
{
    public class CategorySubViewModel
    {
        [DisplayName("子分類編號")]
        public int CategorySubID { get; set; }
        [DisplayName("分類編號")]
        [Required]
        public int CategoryID { get; set; }
        [DisplayName("子分類名稱")]
        [Required]
        [StringLength(50, ErrorMessage = "最多輸入50字元")]
        public string CategoryNameSub { get; set; }
        [DisplayName("子分類說明")]
        [Required]
        [StringLength(200, ErrorMessage = "最多輸入200字元")]
        public string Description { get; set; }

        // 額外加入顯示
        public CategoryViewModel Category { get; set; }

    }
}