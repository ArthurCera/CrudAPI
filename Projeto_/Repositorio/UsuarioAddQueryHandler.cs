using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio
{
    public class UsuarioAddQueryHandler
    {

        private readonly ProjetoContext _ctx;


        public UsuarioAddQueryHandler(ProjetoContext context)
        {
            _ctx = context;
        }

        public async Task<Result> ExecuteAsync(Usuario user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return await InternalExecuteAsync(user);
        }
        private async Task<Result> InternalExecuteAsync(Usuario user)
        {
            var user_ = await (from u in _ctx.Usuario
                              where u.ID == user.ID
                              select u).FirstOrDefaultAsync();
            if (user_ != null) return new Result { UsuarioID = user.ID, message = "ID do usuario já existe no banco de dados!" };
            try
            {
                await _ctx.AddAsync(user);
                await _ctx.SaveChangesAsync();
                return new Result { UsuarioID = user.ID, message = "Usuario Criado com sucesso" };
            }catch(Exception e)
            {
                return new Result { UsuarioID = user.ID, message = e.Message };
            }

        }
        public class Result
        {
            public string message { get; set; }

            public int UsuarioID { get; set; }
        }
    }
}