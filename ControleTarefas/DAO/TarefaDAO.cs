using ControleTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleTarefas.DAO
{
    public class TarefaDAO
    {
        private TarefasContext context = new TarefasContext();
                        
        public void Cadastrar(Tarefa tarefa)
        {
            context.Tarefas.Add(tarefa);
            context.SaveChanges();
        }

        public Tarefa ObterTarefa(int id)
        {
            return context.Tarefas.FirstOrDefault(p => p.Id == id);
        }

        public IList<Tarefa> Listar()
        {
            return context.Tarefas.ToList();
        }

        public void Remover(Tarefa tarefa)
        {
            context.Tarefas.Remove(tarefa);
            context.SaveChanges();
        }

        public void Editar(Tarefa tarefa)
        {
            context.Entry(tarefa).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}