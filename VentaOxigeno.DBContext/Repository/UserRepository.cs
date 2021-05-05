using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public BaseResponse Insert(EntityUser user)
        {
            var returnEntity = new BaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "create_user";
                    var p = new DynamicParameters();
                    p.Add(name: "@userid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@name", value: user.Name, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@email", value: user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@password", value: user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@perfil", value: user.Role, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@user_create", value: user.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityLoginResponse>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    int IdUsuario = p.Get<int>("@userid");

                    returnEntity.isSuccess = true;
                    returnEntity.errorCode = "0000";
                    returnEntity.errorMessage = string.Empty;
                    returnEntity.data = null;
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
        public BaseResponse Login(EntityLogin login)
        {
            var returnEntity = new BaseResponse();
            var entityUser = new EntityLoginResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"user_login";
                    var p = new DynamicParameters();
                    p.Add(name: "@LOGINUSUARIO", value: login.LoginUsuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: login.PasswordUsuario, dbType: DbType.String, direction: ParameterDirection.Input);

                    entityUser = db.Query<EntityLoginResponse>(sql,
                        param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();


                    if (entityUser != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entityUser;
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
