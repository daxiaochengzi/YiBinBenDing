using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Entitys
{
  public class ICD10PairCode
    {
      
            /// <summary>
            /// 
            /// </summary>
            public ICD10PairCode()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            public System.Guid Id { get; set; }

            /// <summary>
            /// 医保目录名称
            /// </summary>
            public System.String ProjectName { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.String ProjectCode { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.Int32? State { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.String PairCodeUserName { get; set; }

            /// <summary>
            /// 基层疾病id
            /// </summary>
            public System.String DiseaseId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.DateTime? CreateTime { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.Byte[] Version { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.DateTime? UpdateTime { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.DateTime? DeleteTime { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.Boolean IsDelete { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.String CreateUserId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.String DeleteUserId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.String UpdateUserId { get; set; }
        }
    }

