using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio
{
    public class UsuarioUpdateQueryHandler
    {

        private readonly ProjetoContext _ctx;


        public UsuarioUpdateQueryHandler(ProjetoContext context)
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

            if (user_ == null) return new Result { UsuarioID = user.ID, message = "Usuario Não Encontrado" };
            try
            {
                _ctx.Entry(user_).State = EntityState.Detached;
                _ctx.Update(user);
                await _ctx.SaveChangesAsync();
                return new Result { UsuarioID = user.ID, message = "Usuario atualizado com sucesso!" };
            } catch(Exception e)
            {
                return new Result { UsuarioID = user.ID, message = e.Message };
            }

        }
        public class Result
        {
            public int UsuarioID { get; set; }
            public string message { get; set; }
        }
    }
}