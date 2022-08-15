using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio
{
    public class UsuarioListQueryHandler
    {

        private readonly ProjetoContext _ctx;


        public UsuarioListQueryHandler(ProjetoContext context)
        {
            _ctx = context;
        }

        public List<Usuario> ExecuteAsync()
        {
            return InternalExecuteAsync();
        }

        private List<Usuario> InternalExecuteAsync()
        {
            try
            {
                var user = (from u in _ctx.Usuario
                            select u).ToList();
                return user;
            }
            catch(Exception e)
            {

                return null;
            }

        }
    }
}