/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Application.SystemManage
{
    public class OrganizeApp
    {
        private IOrganizeRepository service = new OrganizeRepository();

        public List<OrganizeEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.F_CreatorTime).ToList();
        }
        public OrganizeEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        /// <summary>
        /// 获取组织机构列表数据
        /// </summary>
        /// <returns></returns>
        public List<OrganizeEntity> GetListData()
        {
            string findSql = @"select *from [dbo].[Sys_Organize] where F_DeleteMark=0 and F_EnabledMark=1 
                             and F_MedicalInsuranceHandleNo is not null 
                             and F_MedicalInsuranceAccount is not null and F_EnCode<>'yb'";
            return service.FindList(findSql);
        }
        /// <summary>
        /// 更新机构
        /// </summary>
        /// <param name="keyValue"></param>
        public void UpDateEnCode(string keyValue,string enCode)
        {
          var organizeEntity = service.FindEntity(keyValue);
            organizeEntity.Modify(keyValue);
            organizeEntity.F_EnCode=enCode;
            service.Update(organizeEntity);
        }
       
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(OrganizeEntity organizeEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeEntity.Modify(keyValue);
                service.Update(organizeEntity);
            }
            else
            {
                organizeEntity.Create();
                service.Insert(organizeEntity);
            }
        }
    }
}
