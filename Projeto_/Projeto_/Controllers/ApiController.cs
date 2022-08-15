using Microsoft.AspNetCore.Mvc;
using Model;
using Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Text.Json;
using System;

namespace Projeto.Controllers
{
    [Produces("application/json")]
    [Route("api/Controller")]
    public class ApiController : Controller
    {
        [HttpGet("Get")]
        public JsonResult ListUser([FromHeader] string username, [FromHeader] string password, [FromServices] LoginHandler loginHandler,[FromServices] UsuarioListQueryHandler handler)
        {
            Login loginInfo = new Login
            {
                Username = username,
                Password = password
            };
            var login = loginHandler.ExecuteAsync(loginInfo);
            if (login.Result.Success)
            {

                var result = handler.ExecuteAsync();
                return Json(result);
            }
            else
            {
                var return_ = "Login invalido!";
                return Json(return_);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUserFluentValidation([FromHeader] string username, [FromHeader] string password, [FromServices] LoginHandler loginHandler, [FromBody] Usuario command, [FromServices] UsuarioAddQueryHandler handler)
        {
            Login loginInfo = new Login
            {
                Username = username,
                Password = password
            };
            var login = loginHandler.ExecuteAsync(loginInfo);
            if (login.Result.Success)
            {

                UsuarioValidator validator = new UsuarioValidator();
                ValidationResult result_ = validator.Validate(command);
                if (!result_.IsValid)
                {
                    string jsonString = JsonSerializer.Serialize(result_.Errors);
                    return Ok(jsonString);
                }
                var result = await handler.ExecuteAsync(command);
                return Ok(result);
            }
            else
            {
                var return_ = "Login invalido!";
                return Json(return_);
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> CreateUser([FromHeader] string username, [FromHeader] string password, [FromQuery] int ID, [FromServices] UsuarioDeleteQueryHandler handler,[FromServices] LoginHandler loginHandler)
        {
            Login loginInfo = new Login
            {
                Username = username,
                Password = password
            };
            var login = loginHandler.ExecuteAsync(loginInfo);
            if (login.Result.Success)
            {
                var result = await handler.ExecuteAsync(ID);
                return Ok(result);
            }
            else
            {
                var return_ = "Login invalido!";
                return Json(return_);
            }
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateUser([FromHeader] string username, [FromHeader] string password, [FromBody] Usuario command, [FromServices] UsuarioUpdateQueryHandler handler, [FromServices] LoginHandler loginHandler)
        {
            Login loginInfo = new Login
            {
                Username = username,
                Password = password
            };
            var login = loginHandler.ExecuteAsync(loginInfo);
            if (login.Result.Success)
            {

                UsuarioValidator validator = new UsuarioValidator();
                ValidationResult result_ = validator.Validate(command);
                if (!result_.IsValid)
                {
                    string jsonString = JsonSerializer.Serialize(result_.Errors);
                    return Ok(jsonString);
                }
                var result = await handler.ExecuteAsync(command);
                return Ok(result);
            }
            else
            {
                var return_ = "Login invalido!";
                return Json(return_);
            }
        }
        [HttpPost("CreateLogin")]
        public async Task<IActionResult> CreateLogin([FromHeader] string username, [FromHeader] string password, [FromServices] LoginHandler loginHandler, [FromBody] Login command, [FromServices] LoginAddQueryHandler handler)
        {
            Login loginInfo = new Login
            {
                Username = username,
                Password = password
            };
            var login = loginHandler.ExecuteAsync(loginInfo);
            if (login.Result.Success)
            {
                if(command.Username == null || command.Username == "")
                {
                    var res = "{ 'error' ':' 'Username não enviado corretamente!' }";
                    return Json(res);

                }
                else if (command.Password == null || command.Password == "")
                {
                    var res = "{ 'error' ':' 'Senha não enviada corretamente!' }";
                    return Json(res);
                }
                else if (command.ID == 0)
                {
                    var res = "{ 'error' ':' 'ID não enviado corretamente!' }";
                    return Json(res);
                }
                var result = await handler.ExecuteAsync(command);
                return Ok(result);
            }
            else
            {
                var return_ = "Login invalido!";
                return Json(return_);
            }
        }

    }
}
