using ControleTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleTarefas.DAO
{
    public class LoginDAO
    {
        private TarefasContext context = new TarefasContext();
        public List<Usuario> Login(string login)
        {
            return context.Usuarios.Where(p => p.Login == login && p.Ativo == 1).ToList();
        }
    }
}