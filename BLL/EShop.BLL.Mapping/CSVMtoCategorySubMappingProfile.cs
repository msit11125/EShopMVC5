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
    /// CategorySubViewModel 轉換成 CategorySub 的 Mapping
    /// AutoMapper 版本5.0.2 以上新寫法
    /// 參考網址: https://dotblogs.com.tw/yc421206/2016/07/15/automapper_version_5_mapperconfiguration
    /// </summary>
    public class CSVMtoCategorySubMappingProfile : Profile
    {
        //新的方式寫在建構子
        public CSVMtoCategorySubMappingProfile()
        {
            CreateMap<CategorySubViewModel, CategorySub>();
        }


        public override string ProfileName
        {
            get
            {
                return "CSVMtoCategorySubMappingProfile";
            }
        }
    }
}
