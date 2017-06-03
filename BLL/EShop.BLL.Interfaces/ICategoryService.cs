using EShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAllCateogryList();

        CategoryViewModel GetCategoryByID(int id);

        bool AddCategory(CategoryViewModel category);

        bool UpdateCategory(CategoryViewModel category);

        bool DeleteCategory(int id);
    }
}
