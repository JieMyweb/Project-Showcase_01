using AutoMapper;
using pr_model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_service.Config
{
    public class AutoMapperConfigs:Profile
    {
        /// <summary>
        /// 配置映射關係
        /// </summary>
        public AutoMapperConfigs()
        {
            //從A => B
            CreateMap<Book, BookRes>();
            CreateMap<Users, UserRes>();
            CreateMap<RegisterReq, Users>();
        }
    }
}
