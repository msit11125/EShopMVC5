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
    public class PVMtoProductMappingProfile:Profile
    {
        public PVMtoProductMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)  
        }


        public override string ProfileName
        {
            get
            {
                return "PVMtoProductMappingProfile";
            }
        }
    }
}
