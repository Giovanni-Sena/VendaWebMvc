using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendaWebMvc.Data;
using VendaWebMvc.Models;

namespace VendaWebMvc.Servicos
{
    public class DepartamentoService
    {
        private readonly VendaWebMvcContext _context;

        public DepartamentoService( VendaWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> BuscarTodosAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Name).ToListAsync(); // Incluso o await para informar ao compliador que a chamada e Async
        }
    }
}
