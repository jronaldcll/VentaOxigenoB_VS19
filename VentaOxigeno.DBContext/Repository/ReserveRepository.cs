using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ReserveRepository : BaseRepository, IReserveRepository
    {
        public BaseResponse GetReserve(int id)
        {
            var returnEntity = new BaseResponse();
            var entityReserve = new EntityReserve();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProyecto";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entityReserve = db.Query<EntityReserve>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (entityReserve != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entityReserve;
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


        public BaseResponse GetReservePrice(decimal price_min, decimal price_max, string direccion)
        {
            var returnEntity = new BaseResponse();
            var entitiesReserve = new List<EntityReserve>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProyecto_v2";
                    var p = new DynamicParameters();
                    p.Add(name: "@PRECIO_MIN", value: price_min, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO_MAX", value: price_max, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@DIRECCION", value: direccion, dbType: DbType.String, direction: ParameterDirection.Input);

                    entitiesReserve = db.Query<EntityReserve>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesReserve != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesReserve;
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

        public BaseResponse GetReserves()
        {
            var returnEntity = new BaseResponse();
            var entitiesReserve = new List<EntityReserve>();
            

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarProyectos";
                    entitiesReserve = db.Query<EntityReserve>(sql, commandType: CommandType.StoredProcedure).ToList();

                    
                    if (entitiesReserve.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesReserve;
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

        public BaseResponse Insert(EntityReserve reserve)
        {
            var returnEntity = new BaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                   /* const string sql = @"usp_InsertarProyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@NOMBRE", value: reserve.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO", value: reserve.Precio, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@DIRECCION", value: reserve.Direccion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@UBICACION", value: reserve.Ubicacion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIOCREA", value: reserve.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    
                    db.Query<EntityReserve>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idReserve = p.Get<int>("@IDPROYECTO");

                    if (idReserve > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = new
                        {
                            id = idReserve,
                            nombre = reserve.Nombre,
                            precio = reserve.Precio
                        };
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                   */
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

        public BaseResponse GetReservesByProvider(string ProviderEmail)
        {
            var returnEntity = new BaseResponse();
            var entityReserve = new List<EntityReserve>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "list_reserved_provider";

                    var p = new DynamicParameters();
                    p.Add(name: "@email", value: ProviderEmail, dbType: DbType.String, direction: ParameterDirection.Input);

                    entityReserve = db.Query<EntityReserve>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();


                    if (entityReserve != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entityReserve;
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
                returnEntity.errorCode = "0000";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }


        public BaseResponse GetReservesByUser(int id)
        {
            var returnEntity = new BaseResponse();
            var entityReserve = new List<EntityReserveProduct>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "search_reserved_by_user";

                    var p = new DynamicParameters();
                    p.Add(name: "@userid", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entityReserve = db.Query<EntityReserveProduct>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();


                    if (entityReserve != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entityReserve;
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
                returnEntity.errorCode = "0000";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }


        public BaseResponse CreateReserve(EntityReserveProduct reserve)
        {
            var returnEntity = new BaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "create_reserve";
                    var p = new DynamicParameters();
                    p.Add(name: "@reserveid", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@quantity ", value: reserve.quantity, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@price", value: reserve.price, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@userId", value: reserve.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@productId", value: reserve.productId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityReserveProduct>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    int reserveid = p.Get<int>("@reserveid");

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

        public BaseResponse Update_State_Reserve(EntityReserve reserve)
        {
            var returnEntity = new BaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "udp_state_reserve";
                    var p = new DynamicParameters();
                    p.Add(name: "@id", value: reserve.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@stateReserve ", value: reserve.stateReserve, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityReserveProduct>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

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
    }
}
