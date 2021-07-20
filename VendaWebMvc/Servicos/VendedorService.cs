using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMvc.Data;
using VendaWebMvc.Models;

namespace VendaWebMvc.Servicos
{
    public class VendedorService
    {
        private readonly VendaWebMvcContext _context;

        public VendedorService(VendaWebMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> BuscarTodos()
        {
            return _context.Vendedores.ToList();
        }

        public void Insert(Vendedor insertVendedor)
        {
            _context.Add(insertVendedor);
            _context.SaveChanges();
        }
    }
}
