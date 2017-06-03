using EShop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.ViewModels;
using EShop.DAL.Interfaces;
using EShop.Models;
using AutoMapper;
using System.Linq.Expressions;

namespace EShop.BLL.Service
{
    public class ProductService : IProductService
    {
        IRepository<Product> _product;
        public ProductService(IRepository<Product> product)
        {
            _product = product;
        }
        public IEnumerable<ProductViewModel> GetProductList(int categrySubID)
        {
            var pList = _product.Get(filter: c => c.CategorySubID == categrySubID);
            var mapResult = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(pList);

            return mapResult;
        }


        public ProductViewModel GetProductByID(int id)
        {
            var product = _product.GetByID(id);
            var mapResult = Mapper.Map<Product, ProductViewModel>(product);

            return mapResult;
        }


        public bool AddProduct(ProductViewModel product)
        {
            var mapResult = Mapper.Map<ProductViewModel, Product>(product);
            try
            {
                _product.Insert(mapResult);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }



        public bool UpdateProduct(ProductViewModel product)
        {
            var mapResult = Mapper.Map<ProductViewModel, Product>(product);
            try
            {
                _product.Update(mapResult);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeleteProduct(int id)
        {
            try
            {
                _product.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
