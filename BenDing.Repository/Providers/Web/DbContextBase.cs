using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Entitys;
using NFine.Code;
using SqlSugar;

namespace BenDing.Repository.Providers.Web
{
   public class DbContextBase<T> where T: class,new()
    {
        private readonly Log _log;
        public SqlSugarClient _db;//用来处理事务多表查询和复杂的操作
       
        public DbContextBase()
        {
           
            _db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["NFineDbContext"].ToString(),
                    DbType = DbType.SqlServer,//设置数据库类型
                    IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                    InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息
                    
                });
            _log = LogFactory.GetLogger("ini".GetType().ToString());
            _db.Aop.OnError = (exp) =>//执行SQL 错误事件
            {
                _log.Debug(exp.Sql);
                _log.Error(exp.Message);
            };

        }

       
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(_db); } }//用来处理T表的常用操作


        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {// entity.GetType().Name


            return _db.SqlQueryable<T>($"select * from {new T().GetType().Name} where IsDelete=0").ToList();
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic id)
        {
            return CurrentDb.Delete(id);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }

    }
  
}
