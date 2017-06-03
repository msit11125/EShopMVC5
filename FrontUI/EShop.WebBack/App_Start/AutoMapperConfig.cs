using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.WebBack
{
    public class AutoMapperConfig
    {
        // AutoMapper 註冊初始化
        public static void Configure()
        {

            // 讀取已註冊的Profile
            var profiles = DependencyResolver.Current.GetServices<Profile>();

            // 實際開始CreateMap
            Mapper.Initialize(
                i =>
                {
                    foreach (var profile in profiles)
                    {
                        i.AddProfile(profile);
                    }
                }
            );


            // 最後 Global.asax : AutoMapperConfig.Configure();
        }
    }
}