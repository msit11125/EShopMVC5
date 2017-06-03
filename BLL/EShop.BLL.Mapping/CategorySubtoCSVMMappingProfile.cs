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
    /// CategorySub 轉換成 CategorySubViewModel 的 Mapping
    /// AutoMapper 版本5.0.2 以上新寫法
    /// 參考網址: https://dotblogs.com.tw/yc421206/2016/07/15/automapper_version_5_mapperconfiguration
    /// </summary>
    public class CategorySubtoCSVMMappingProfile : Profile
    {
        //新的方式寫在建構子
        public CategorySubtoCSVMMappingProfile()
        {
            //更複雜的automapper實作 可參考: http://kevintsengtw.blogspot.tw/2014/03/automapper-queryable-extensions.html
            //建立對映設定 

            // Map CategorySubViewModel 內的 CategoryName
            CreateMap<Category, CategorySubViewModel>()
                .ForMember(x => x.CategoryID,
                           y => y.Ignore());

            CreateMap<CategorySub, CategorySubViewModel>()
                .ForMember(x => x.Description,
                          y => y.MapFrom(s => s.Description +
                          "。最後編輯時間: " +
                          DateTime.Now.ToString("yyyy-MM-dd")));




             
        }


        public override string ProfileName
        {
            get
            {
                return "CategorySubtoCSVMMappingProfile";
            }
        }
    }
}
