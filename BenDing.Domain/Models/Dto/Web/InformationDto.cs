using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.Web
{
   public class InformationDto
    {/// <summary>
     /// 目录编码
     /// </summary>
       
       
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 目录名称
        /// </summary>
       
        public string DirectoryName { get; set; }
        /// <summary>
        /// 助记码
        /// </summary>
       
        public string MnemonicCode { get; set; }
        /// <summary>
        /// 目录类别名称
        /// </summary>
        
        public string DirectoryCategoryName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
      
        public string Remark { get; set; }
   
    }
}
