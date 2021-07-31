using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMvc.Servicos;

namespace VendaWebMvc.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroDeVendaService _registroDeVendaService;

        public RegistroDeVendasController(RegistroDeVendaService registroDeVendaService)
        {
            _registroDeVendaService = registroDeVendaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples( DateTime? dataMin, DateTime? dataMax)
        {
            var reseultado = await _registroDeVendaService.BuscaPorDataAsync(dataMin, dataMax);
            return View(reseultado);
        }

        public IActionResult BuscaPorGrupo()
        {
            return View();
        }
    }
}
