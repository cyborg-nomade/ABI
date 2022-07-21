﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CPTM.ABI.WebApi.Models;
using CPTM.ActiveDirectory;

namespace CPTM.ABI.WebApi.Controllers.API
{
    [RoutePrefix("api/ad")]
    public class ActiveDirectoryController : ApiController
    {
        [Route("obter-usuario/{username}")]
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage ObterUsuario([FromUri] string username)
        {
            var usuarioAd = Seguranca.ObterUsuario(username);
            return Request.CreateResponse(HttpStatusCode.OK, new { usuarioAd });
        }

        [Route("existe-usuario/{username}")]
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage ExisteUsuario([FromUri] string username)
        {
            var existe = Seguranca.Existe(username);
            return Request.CreateResponse(HttpStatusCode.OK, new { existe });
        }

        [Route("autenticar")]
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Autenticar([FromBody] AuthUser authUser)
        {
            var autenticado = Seguranca.Autenticar(authUser.username, authUser.password);
            return Request.CreateResponse(HttpStatusCode.OK, new { autenticado });
        }
    }
}