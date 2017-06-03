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
    /// Category 轉換成 CategoryViewModel 的 Mapping
    /// AutoMapper 版本5.0.2 以上新寫法
    /// 參考網址: https://dotblogs.com.tw/yc421206/2016/07/15/automapper_version_5_mapperconfiguration
    /// </summary>
    public class CVMtoCategoryMappingProfile : Profile
    {
        //新的方式寫在建構子
        public CVMtoCategoryMappingProfile()
        {
            CreateMap<CategoryViewModel,Category> ();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)  
        }


        public override string ProfileName
        {
            get
            {
                return "CVMtoCategoryMappingProfile";
            }
        }
    }
}
