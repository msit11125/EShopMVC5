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
    public class CategorySubService:ICategorySubService
    {
        IRepository<CategorySub> _categorysub;
        public CategorySubService(IRepository<CategorySub> categorysub)
        {
            _categorysub = categorysub;
        }

        public IEnumerable<CategorySubViewModel> GetCategorySubList(int categoryID)
        {
            var csList = _categorysub.Get(filter:c=>c.CategoryID == categoryID);

            //資料對應
            var mapResult = Mapper.Map<IEnumerable<CategorySub>, IEnumerable<CategorySubViewModel>>(csList);

            return mapResult;
        }

        public CategorySubViewModel GetCategorySubByID(int id)
        {
            var cate = _categorysub.GetByID(id);

            //資料對應
            var mapResult = Mapper.Map<CategorySub, CategorySubViewModel>(cate);

            return mapResult;
        }



        public bool AddCategorySub(CategorySubViewModel category)
        {
            //資料對應
            var mapResult = Mapper.Map<CategorySubViewModel, CategorySub>(category);
            try
            {
                _categorysub.Insert(mapResult);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool UpdateCategorySub(CategorySubViewModel category)
        {
            //資料對應
            var mapResult = Mapper.Map<CategorySubViewModel, CategorySub>(category);

            try
            {
                _categorysub.Update(mapResult);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteCategorySub(int id)
        {
            try
            {
                _categorysub.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
