using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using VentaOxigeno.API.Security;

namespace UPC.Business.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    [ApiController] //Para que lo muestre como Json
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntityLogin login)
        {
            var ret = _UserRepository.Login(login);

            if (ret.data != null)
            {
                var responseLogin = ret.data as EntityLoginResponse;
                var userId = responseLogin.IdUser.ToString();
                var userNom = responseLogin.Nombres;

                var token = JsonConvert
                    .DeserializeObject<AccessToken>(
                        await new Authentication()
                        .GenerateToken(userNom, userId)
                        ).access_token;

                responseLogin.Token = token;
                ret.data = responseLogin;
            }
            //return StatusCode(401);

            return Json(ret);
        }


        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("registeruser")]
        public ActionResult Insert(EntityUser user)
        {
            var userId ="";
            var identity = User.Identity as ClaimsIdentity;
            if (identity == null || !identity.IsAuthenticated)
            {
                userId = "0";
            }
            else
            {
                IEnumerable<Claim> claims = identity.Claims;

                var usuarioId = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault().Value;
                var userNom = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault().Value;
                userId = usuarioId;
            }

            user.UsuarioCrea = int.Parse(userId);
            var ret = _UserRepository.Insert(user);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

    }
}