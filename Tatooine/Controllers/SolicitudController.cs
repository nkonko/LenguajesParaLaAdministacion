namespace Tatooine.Controller
{
    using BE;
    using BLL.Interfaces;
    using BLL.Utils;
    using System.Collections.Generic;
    using System.Web.Http;

    public class SolicitudController : ApiController
    {
        private IAltaSolicitudBusiness altaSolicitudBusiness = IOCContainer.Resolve<IAltaSolicitudBusiness>();

        //GET api/<controller>/
        [HttpGet]
        public IEnumerable<AltaSolicitud> Get()
        {
            var solicitudes = altaSolicitudBusiness.Get();

            return solicitudes;
        }

        //POST api/<controller>/
        [HttpPost]
        public IHttpActionResult Post(AltaSolicitud solicitud)
        {
            var response = false;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (solicitud != null)
            {
                response = altaSolicitudBusiness.Add(solicitud);
            }

            if (!response)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
