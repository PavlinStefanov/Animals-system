using AnimalsSupportSystem.Business.Domain;
using AnimalsSupportSystem.Business.Utils.Dto;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnimalsSupportSystem.WebApi.Controllers
{
    [RoutePrefix("api/medicalSystem")]
    public class MedicalSystemController : ApiController
    {
        private readonly ICommandFactory _commandFactory;

        public MedicalSystemController(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        [Route("processCommands")]
        [HttpPost]
        public HttpResponseMessage ProcessCommands(HttpRequestMessage requestMessage, CommandsMapper commands)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                var handler = new MedicalHandler(commands, _commandFactory);
                handler.ProcessHandlers();

                responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest);
            }
            return responseMessage;
        }
    }
}
