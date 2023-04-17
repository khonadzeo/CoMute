using CoMute.Web.Models;
using CoMute.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CoMute.Web.Controllers.API
{
    public class UserController : ApiController
    {
        [System.Web.Mvc.Route("user/add")]
        public HttpResponseMessage Post(RegistrationRequest registrationRequest)
        {
            var user = new User()
            {
                Name = registrationRequest.Name,
                Surname = registrationRequest.Surname,
                EmailAddress = registrationRequest.EmailAddress,
                PhoneNumber= registrationRequest.PhoneNumber,
                Password= registrationRequest.Password
            };

            return Request.CreateResponse(HttpStatusCode.Created, user);
        }

    }
}
