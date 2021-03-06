﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Infrastructures
{
    public class IBaseEntity<TEntity>
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
        public void IniCreate(UserInfoDto user)
        {
            var entity = this as IBaseCreationAudited;
            if (entity != null)
            {


                entity.CreateUserId = user.UserId;
                entity.CreateTime = DateTime.Now;
                entity.OrganizationName = user.OrganizationName;
                entity.OrganizationCode = user.OrganizationCode;


            }


        }/// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public void IniModify(Guid id, string userId)
        {
            var entity = this as IBaseModificationAudited;
            entity.Id = id;
            entity.UpdateUserId = userId;
            entity.UpdateTime = DateTime.Now;
        }
        public void Remove(Guid id, string userId)
        {
            var entity = this as IBaseDeleteAudited;
            entity.Id = id;
            entity.DeleteUserId = userId;
            entity.DeleteTime = DateTime.Now;
            entity.IsDelete = true;
        }
    }
}
