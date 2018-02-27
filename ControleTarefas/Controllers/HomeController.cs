using ControleTarefas.DAO;
using ControleTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleTarefas.Controllers
{
    public class HomeController : Controller
    {
        private TarefaDAO taferaDAO = new TarefaDAO();
        private LoginDAO loginDAO = new LoginDAO();

        // GET: Home
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string senha)
        {
            var obj = loginDAO.Login(login);
            if (obj == null)
                ModelState.AddModelError("login.Invalido", "Usuário não encontrado!");
            else
            {
                var objLog = obj.FirstOrDefault(p => p.Senha == senha);
                if (objLog == null)
                    ModelState.AddModelError("login.Invalido", "Usuário ou senha inválido!");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Listar");
            }

            return View("Index");
        }

        public ActionResult Listar()
        {
            var Tarefas = ListarTarefas(5, "");
            return View(Tarefas);
        }

        public ActionResult Cadastrar()
        {
            return View();           
        }

        [HttpPost]
        public ActionResult Cadastrar(Tarefa tarefa)
        {            
            if (ModelState.IsValid)
            {                   
                taferaDAO.Cadastrar(tarefa);
                return RedirectToAction("Listar");
            }
            else
            {
                return View("Listar", tarefa);
            }
        }

        public ActionResult Editar(int id)
        {
            var obj = taferaDAO.ObterTarefa(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Editar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                taferaDAO.Editar(tarefa);
                return RedirectToAction("Listar");
            }
            else
            {
                return View("Listar", tarefa);
            }
        }

        public ActionResult Remover(int id)
        {
            var obj = taferaDAO.ObterTarefa(id);
            taferaDAO.Remover(obj);
            return RedirectToAction("Listar");
        }

        public ActionResult Filtro(string filtro)
        {
            var obj = ListarTarefas(0, filtro);
            return View("Listar", obj);
        }

        private List<Tarefa> ListarTarefas(int qtde, string filtro)
        {
            var lst = taferaDAO.Listar();

            if (qtde > 0 && string.IsNullOrEmpty(filtro))
                return lst.OrderByDescending(p => p.DataExcucao).Take(qtde).ToList();

            if (!string.IsNullOrEmpty(filtro))
                return lst.Where(p => p.Titulo.Contains(filtro)).OrderByDescending(p => p.DataExcucao).ToList();

            return new List<Tarefa>();
        }
    }
}