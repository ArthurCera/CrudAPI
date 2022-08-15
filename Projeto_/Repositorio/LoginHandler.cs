using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio
{
    public class LoginHandler
    {

        private readonly ProjetoContext _ctx;


        public LoginHandler(ProjetoContext context)
        {
            _ctx = context;
        }

        public async Task<Result> ExecuteAsync(Login user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return await InternalExecuteAsync(user);
        }
        private async Task<Result> InternalExecuteAsync(Login user)
        {
            try
            {
                var user_ = (from u in _ctx.Login
                                   where u.Username == user.Username
                                   && u.Password == user.Password
                                   select u).FirstOrDefault();
                if (user_ != null) {
                    return new Result { Success = true };
                }
                else return new Result{ Success = false } ;
            }
            catch (Exception e)
            {
                 return new Result { Success = false };
            }

        }
        public class Result
        {
            public bool Success { get; set; }
        }
    }
}