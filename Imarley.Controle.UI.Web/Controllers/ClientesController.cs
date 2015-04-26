using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Imarley.Controle.Application.Interface;
using Imarley.Controle.Domain.Entities;
using Imarley.Controle.UI.Web.ViewModels;

namespace Imarley.Controle.UI.Web.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly IStatusAppService _statusApp;
        private readonly ICategoriaAppService _categoriaApp;
        private readonly IClienteAppService _clienteApp;
        
        public ClientesController(IStatusAppService statusApp, ICategoriaAppService categoriaApp, IClienteAppService clienteApp)
        {
            _statusApp = statusApp;
            _categoriaApp = categoriaApp;
            _clienteApp = clienteApp;
        }
        
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.Listar());
            return View(clienteViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(_categoriaApp.Listar(), "Id", "Nome");
            ViewBag.Status = new SelectList(_statusApp.Listar(),"Id", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            try
            {
                var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel); 
                _clienteApp.Cadastrar(cliente);

                TempData["sucesso"] = "Cliente cadastrado com sucesso";
                
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["erro"] = "Erro ao cadastrado categoria";

                ViewBag.Categorias = new SelectList(_categoriaApp.Listar(), "Id", "Nome");
                ViewBag.Status = new SelectList(_statusApp.Listar(), "Id", "Nome");

                return View(clienteViewModel);
            }
        }

        
        public ActionResult Edit(int id)
        {
            ViewBag.Categorias = new SelectList(_categoriaApp.Listar(), "Id", "Nome");
            ViewBag.Status = new SelectList(_statusApp.Listar(),"Id", "Nome");

            var cliente = _clienteApp.Pesquisar(x => x.Id == id).Single();
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente); 

            return View(clienteViewModel);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel clienteViewModel)
        {
            try
            {
                var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                _clienteApp.Atualizar(cliente);

                TempData["sucesso"] = "Cliente atualizado com sucesso";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["erro"] = "Erro ao atualizar cliente";

                ViewBag.Categorias = new SelectList(_categoriaApp.Listar(), "Id", "Nome");
                ViewBag.Status = new SelectList(_statusApp.Listar(), "Id", "Nome");

                return View();
            }
        }
        
        

        public ActionResult Delete(int id)
        {
            try
            {
                _clienteApp.Deletar(id);
                TempData["sucesso"] = "Cliente excluído com sucesso";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["erro"] = "Erro ao excluir cliente";
                return RedirectToAction("Index");
            }
        } 
    }
}