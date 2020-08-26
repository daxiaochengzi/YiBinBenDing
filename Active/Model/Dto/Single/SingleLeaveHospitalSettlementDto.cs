﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model.Dto.Single
{/// <summary>
 /// 单病种费用结算
 /// </summary>
    public class SingleLeaveHospitalSettlementDto:IniDto
    {/// <summary>
     /// 结算记录号
     /// </summary>
        public string PO_AAZ216 { get; set; }
        /// <summary>
        /// 发生费用金额  
        /// </summary>
        public string PO_FYZE { get; set; }
        /// <summary>
        /// 基本统筹支付
        /// </summary>
        public string PO_TCZF { get; set; }
        /// <summary>
        /// 居民大病保险支付金额  
        /// </summary>
        public string PO_DBZF { get; set; }
        /// <summary>
        /// 职工补充医疗支付金额
        /// </summary>
        public string PO_BCZF { get; set; }
        /// <summary>
        /// 职工公务员补助支付金额  
        /// </summary>
        public string PO_GWYBZ { get; set; }
        /// <summary>
        /// 民政救助报销支付金额
        /// </summary>
        public string PO_MZJZ { get; set; }
        /// <summary>
        /// 民政重大疾病救助报销支付金额  
        /// </summary>
        public string PO_MZDBJZ { get; set; }
        /// <summary>
        /// 精准扶贫报销支付金额
        /// </summary>
        public string PO_JZFP { get; set; }
        /// <summary>
        /// 民政优扶报销支付金额  
        /// </summary>
        public string PO_MZYF { get; set; }
        /// <summary>
        /// 单病种限价标准
        /// </summary>
        public string PO_DBZXJBZ { get; set; }
        /// <summary>
        /// 超单病种限价标准医院承担费用  
        /// </summary>
        public string POPO_DBZYYZF_MSG { get; set; }
        /// <summary>
        /// 未达单病种限价标准补给医院差额
        /// </summary>
        public string PO_DBZYYCE { get; set; }
        /// <summary>
        /// 患者支付金额  
        /// </summary>
        public string PO_XJZF { get; set; }
        /// <summary>
        /// 起付金额
        /// </summary>
        public string PO_QFJE { get; set; }
        /// <summary>
        /// 单据号  
        /// </summary>
        public string PO_DJH { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string PO_BZ { get; set; }

    }
}
