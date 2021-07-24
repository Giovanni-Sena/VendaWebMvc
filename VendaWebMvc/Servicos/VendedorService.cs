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

        public Vendedor EncontrarPorId(int id)
        {
            return _context.Vendedores.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Vendedores.Find(id);
            _context.Vendedores.Remove(obj);
            _context.SaveChanges();
        }
    }
}
