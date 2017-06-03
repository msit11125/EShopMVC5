using EShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProductList(int categrySubID);
        ProductViewModel GetProductByID(int id);

        bool AddProduct(ProductViewModel product);

        bool UpdateProduct(ProductViewModel product);

        bool DeleteProduct(int id);
    }
}
