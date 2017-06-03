using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels
{
    public class CategoryViewModel
    {
        [DisplayName("分類編號")]
        public int CategoryID { get; set; } //流水號
        [DisplayName("分類名稱")]
        [Required]
        [StringLength(50,ErrorMessage ="最多輸入50字元")]
        public string CategoryName { get; set; }

    }


}
