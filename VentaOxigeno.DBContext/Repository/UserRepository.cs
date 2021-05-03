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
                    const string sql = @"usp_InsertarUuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSUARIO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@LOGINUSUARIO", value: user.LoginUsuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: user.PasswordUsuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@ROLE", value: user.Role, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRE", value: user.Nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: user.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    db.Query<EntityLoginResponse>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    int IdUsuario = p.Get<int>("@IDUSUARIO");

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
                    const string sql = @"usp_user_login";
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
