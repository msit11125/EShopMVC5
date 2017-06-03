using AutoMapper;
using EShop.BLL.Interfaces;
using EShop.DAL.Interfaces;
using EShop.Models;
using EShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Service
{
    public class CategoryService: ICategoryService
    {
        IRepository<Category> _category;

        public CategoryService(IRepository<Category> category)
        {
            this._category = category;
        }



        public IEnumerable<CategoryViewModel> GetAllCateogryList()
        {
            //獲得所有母分類集合
            var cList = _category.Get();

            //資料對應
            var mapResult = Mapper.Map<IEnumerable<Category>,IEnumerable<CategoryViewModel>>(cList);
            
            return mapResult;
        }



        public CategoryViewModel GetCategoryByID(int id)
        {
            var cate = _category.GetByID(id);


            //資料對應
            var mapResult = Mapper.Map<Category, CategoryViewModel>(cate);

            return mapResult;
        }



        public bool AddCategory(CategoryViewModel category)
        {
            //資料對應
            var mapResult = Mapper.Map<CategoryViewModel, Category>(category);
            try
            {
                _category.Insert(mapResult);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool UpdateCategory(CategoryViewModel category)
        {
            //資料對應
            var mapResult = Mapper.Map<CategoryViewModel, Category>(category);

            try
            {
                _category.Update(mapResult);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteCategory(int id)
        {
            try
            {
                _category.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
