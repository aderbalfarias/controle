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
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _categoriaApp;
        public CategoriasController(ICategoriaAppService categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }
        
        public ActionResult Index()
        {
            var categoriaViewModel = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaApp.Listar());
            return View(categoriaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            try
            {
                var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel); 
                _categoriaApp.Cadastrar(categoria);

                TempData["sucesso"] = "Categoria cadastrada com sucesso";
                
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["erro"] = "Erro ao cadastrar categoria";
                return View(categoriaViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
            var categoria = _categoriaApp.Pesquisar(x => x.Id == id).Single();
            var categoriaViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoria); 

            return View(categoriaViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaViewModel categoriaViewModel)
        {
            try
            {
                var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
                _categoriaApp.Atualizar(categoria);

                TempData["sucesso"] = "Categoria atualizada com sucesso";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["erro"] = "Erro ao atualizar categoria";
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                _categoriaApp.Deletar(id);
                TempData["sucesso"] = "Categoria excluída com sucesso";


                return RedirectToAction("Index");
            }
            catch
            {
                TempData["erro"] = "Erro ao excluir categoria";
                return RedirectToAction("Index");
            }
        }
    }
}
