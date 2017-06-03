using EShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Interfaces
{
    public interface ICategorySubService
    {
        IEnumerable<CategorySubViewModel> GetCategorySubList(int categryID);
        CategorySubViewModel GetCategorySubByID(int id);

        bool AddCategorySub(CategorySubViewModel category);

        bool UpdateCategorySub(CategorySubViewModel category);

        bool DeleteCategorySub(int id);
    }
}
