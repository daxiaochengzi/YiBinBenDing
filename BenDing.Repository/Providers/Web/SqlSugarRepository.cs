using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Entitys;
using BenDing.Repository.Interfaces.Web;
using Dapper;
using NFine.Code;
using SqlSugar;

namespace BenDing.Repository.Providers.Web
{
  public  class SqlSugarRepository: ISqlSugarRepository
    {
        private readonly Log _log;

        private readonly SqlSugarClient _db;

        public SqlSugarRepository()
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

       
        public void QueryHospitalLog()
        {
            var list = _db.Queryable<HospitalLog>().ToList();//查询所有
        }
        /// <summary>
        /// icd10已对码查询
        /// </summary>
        /// <returns></returns>
        public List<ICD10PairCode> QueryICD10PairCode()
        {
            var list = _db.Queryable<ICD10PairCode>().ToList();//查询所有
            return list;
        }
    }
}
