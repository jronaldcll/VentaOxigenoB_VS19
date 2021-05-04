using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ProviderRepository : BaseRepository, IProviderRepository
    {
        public BaseResponse SearchById(int id)
        {
            var returnEntity = new BaseResponse();
            var provider = new EntityProvider();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "search_provider";
                    var p = new DynamicParameters();
                    //p.Add(name: "@userid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    //p.Add(name: "@email", value: user.email, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add(name: "@password", value: user.password, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add(name: "@perfil", value: user.role, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add(name: "@user_create", value: user.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    provider = db.Query<EntityProvider>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    //int IdUsuario = p.Get<int>("@userid");

                    if (provider != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = provider;
                    } else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }

                    
                }

            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }

    }
}
