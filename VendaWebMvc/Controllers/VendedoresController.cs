using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMvc.Servicos;
using VendaWebMvc.Models;
using VendaWebMvc.Models.ViewModels;
using VendaWebMvc.Servicos.Excecao;

namespace VendaWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var lista = _vendedorService.BuscarTodos();
            
            return View(lista);
        }

        public IActionResult Criar()
        {
            var departamentos = _departamentoService.BuscarTodos();
            var viewModel = new VendedorFormViewModel {Departamentos = departamentos };
            return View(viewModel); // Incluir o viewModel para retorna a lista de departamento
        }
        [HttpPost] // Incluindo para utilizar o metedo Post
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _vendedorService.EncontrarPorId(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _vendedorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedorService.EncontrarPorId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Editar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _vendedorService.EncontrarPorId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Departamento> departamentos = _departamentoService.BuscarTodos();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if(id != vendedor.Id)
            {
                return NotFound();
            }
            try
            {
                _vendedorService.Atualizar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
