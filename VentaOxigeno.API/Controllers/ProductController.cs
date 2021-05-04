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
    [Route("api/Product")]
    [ApiController] //Para que lo muestre como Json
    public class ProductController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IProductRepository _ProductRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductRepository"></param>
        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;

        }

        /// <summary>
        /// SearchById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("searchByProviderId")]
        public async Task<ActionResult> SearchByProviderId(int id)
        {
            var ret = _ProductRepository.SearchByProviderId(id);

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
