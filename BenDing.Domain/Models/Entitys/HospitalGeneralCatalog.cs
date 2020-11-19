using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Entitys
{
   public class HospitalGeneralCatalog
    { /// <summary>
      /// 
      /// </summary>
        public HospitalGeneralCatalog()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 机构编码[取接口30返回的ID]
        /// </summary>
        public System.String OrganizationCode { get; set; }

        /// <summary>
        /// 目录类型[0科室、1医生、2病区、3床位]
        /// </summary>
        public System.String DirectoryType { get; set; }

        /// <summary>
        /// 目录编码
        /// </summary>
        public System.String DirectoryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String FixedEncoding { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        public System.String MnemonicCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String DirectoryName { get; set; }

        /// <summary>
        /// 目录类别名称
        /// </summary>
        public System.String DirectoryCategoryName { get; set; }

        /// <summary>
        /// 备注[目录类型1： 返回医生所在科室的编码;目录类型3： 返回床位所在的病区编码.]
        /// </summary>
        public System.String Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新标记
        /// </summary>
        public System.Byte[] Version { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 删除标记[0:默认,1:删除]
        /// </summary>
        public System.Boolean IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public System.DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 操作员ID-[创建]
        /// </summary>
        public System.String CreateUserId { get; set; }

        /// <summary>
        /// 操作员ID-[删除]
        /// </summary>
        public System.String DeleteUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String UpdateUserId { get; set; }

        /// <summary>
        /// 上传标识 1 职业信息上传 2 上传成功
        /// </summary>
        public System.Int32? UploadMark { get; set; }
    }
}
