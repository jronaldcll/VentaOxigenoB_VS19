using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
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
    [Route("api/Provider")]
    [ApiController] //Para que lo muestre como Json
    public class ProviderController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IProviderRepository _ProviderRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProviderRepository"></param>
        public ProviderController(IProviderRepository ProviderRepository)
        {
            _ProviderRepository = ProviderRepository;

        }

        /// <summary>
        /// SearchById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("searchById")]
        public async Task<ActionResult> SearchById(int id)
        {
            var ret = _ProviderRepository.SearchById(id);

            if (ret.data != null)
            {
                /*var response = ret.data as EntityProvider;
                var userId = responseLogin.IdUsuario.ToString();
                var userDoc = responseLogin.DocumentoIdentidad;

                var token = JsonConvert
                    .DeserializeObject<AccessToken>(
                        await new Authentication()
                        .GenerateToken(userDoc, userId)
                        ).access_token;

                responseLogin.Token = token;
                ret.data = responseLogin;*/
            }
            //return StatusCode(401);

            return Json(ret);
        }
    }
}