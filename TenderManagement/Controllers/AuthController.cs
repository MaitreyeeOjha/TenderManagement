using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TM.Data;
using TM.Data.Repository;

namespace TenderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserRepository _repository;

        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string userid, string password)
        {
            User user = _repository.GetUser(userid, password);
            if (user == null)
            {
                return Unauthorized();
                
            }
            else
            {
                JWTFactory authentication = new JWTFactory();
                string token = authentication.GenerateTokenForUser(user.UserName, user.UserId);
                return Ok( token);
                //return Request.CreateResponse(HttpStatusCode.OK, token, Configuration.Formatters.JsonFormatter);
            }
        }
    }
}