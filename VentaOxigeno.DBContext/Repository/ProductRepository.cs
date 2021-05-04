using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public BaseResponse SearchByProviderId(int id)
        {
            var returnEntity = new BaseResponse();
            var products = new List<EntityProduct>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "search_product_providerId";
                    var p = new DynamicParameters();
                    //p.Add(name: "@userid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@providerId", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    //p.Add(name: "@email", value: user.email, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add(name: "@password", value: user.password, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add(name: "@perfil", value: user.role, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add(name: "@user_create", value: user.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    products = db.Query<EntityProduct>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                    //int IdUsuario = p.Get<int>("@userid");

                    if (products.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = products;
                    }
                    else
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
