using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public List<Departamento> BuscarTodos()
        {
            return _context.Departamento.OrderBy(x => x.Name).ToList();
        }
    }
}
