using AutoMapper;
using EShop.Models;
using EShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Mappings
{
    /// <summary>
    /// CategoryViewModel 轉換成 Category 的 Mapping
    /// AutoMapper 版本5.0.2 以上新寫法
    /// 參考網址: https://dotblogs.com.tw/yc421206/2016/07/15/automapper_version_5_mapperconfiguration
    /// </summary>
    public class CategorytoCVMMappingProfile : Profile
    {
        //新的方式寫在建構子
        public CategorytoCVMMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }


        public override string ProfileName
        {
            get
            {
                return "CategorytoCVMMappingProfile ";
            }
        }
    }
}
