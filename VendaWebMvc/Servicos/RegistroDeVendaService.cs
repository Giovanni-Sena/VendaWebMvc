using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendaWebMvc.Data;
using VendaWebMvc.Models;

namespace VendaWebMvc.Servicos
{
    public class RegistroDeVendaService
    {
        private readonly VendaWebMvcContext _context;

        public RegistroDeVendaService(VendaWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<HistoricoDeVendas>> BuscaPorDataAsync( DateTime? dataMin, DateTime? dataMax)
        {
            var resultado = from obj in _context.HistoricoDeVendas select obj;
            if (dataMin.HasValue)
            {
                resultado = resultado.Where(x => x.Date >= dataMin.Value);
            }
            if (dataMax.HasValue)
            {
                resultado = resultado.Where(x => x.Date <= dataMax.Value);
            }
            return await resultado
                .Include( x => x.Vendedor) // Realizando o join com a tabela Vendedor.
                .Include( x => x.Vendedor.Departamento) // Realizando o join com a tabela Departamento.
                .OrderByDescending( x => x.Date)
                .ToListAsync();
        }
    }
}
