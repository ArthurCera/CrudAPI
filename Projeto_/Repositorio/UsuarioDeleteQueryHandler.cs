using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio
{
    public class UsuarioDeleteQueryHandler
    {

        private readonly ProjetoContext _ctx;


        public UsuarioDeleteQueryHandler(ProjetoContext context)
        {
            _ctx = context;
        }

        public async Task<Result> ExecuteAsync(int UsuarioID)
        {
            if (UsuarioID == 0)
            {
                throw new ArgumentNullException("ID do usuario não foi passado corretamente!");
            }
            return await InternalExecuteAsync(UsuarioID);
        }
        private async Task<Result> InternalExecuteAsync(int UsuarioID)
        {
            var user = await (from u in _ctx.Usuario
                              where u.ID == UsuarioID
                        select u).FirstOrDefaultAsync();
            if (user == null) return new Result { UsuarioID = UsuarioID, message = "Usuario Não Encontrado" };
            try
            {
                _ctx.Remove(user);
                await _ctx.SaveChangesAsync();
                return new Result { UsuarioID = user.ID, message="Usuario deletado com sucesso!" };
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