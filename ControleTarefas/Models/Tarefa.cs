using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Título é obigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obigatório!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Data de Execução é obigatório!")]
        public DateTime DataExcucao { get; set; }        
    }
}