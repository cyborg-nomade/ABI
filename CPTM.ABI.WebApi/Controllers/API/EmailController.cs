using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CPTM.ABI.WebApi.Models;
using CPTM.ActiveDirectory;
using CPTM.GNU.Library;

namespace CPTM.ABI.WebApi.Controllers.API
{
    [RoutePrefix("api/email")]
    public class EmailController : ApiController
    {
        [Route("enviar")]
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage ObterUsuario([FromUri] EmailArgs emailArgs)
        {
            var erro = emailArgs.MensagemErro;
            var enviado = Email.Enviar(emailArgs.SistemaSigla, emailArgs.RementeNome, emailArgs.RemetenteEmail,
                emailArgs.Destinatarios, emailArgs.Assunto, emailArgs.Mensagem, emailArgs.EnviarEm,
                emailArgs.IdUsuarioCpu, ref erro);

            return Request.CreateResponse(HttpStatusCode.OK, new { enviado });
        }
    }
}