using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMvc.Models;
using VendaWebMvc.Models.Enums;

namespace VendaWebMvc.Data
{
    public class DbService
    {
        private VendaWebMvcContext _context;

        public DbService( VendaWebMvcContext context)
        {
            _context = context;
        }

        public void PopularDb()
        {
            if(_context.Departamento.Any() || 
                _context.Vendedors.Any() ||
                _context.HistoricoDeVendas.Any())
            {
                return; // Informações já populadas.
            }

            Departamento dep = new Departamento(1, "Computador");

            Vendedor vend = new Vendedor(1, "Sena", new DateTime (1991,10,18), "sena@sena.com", 1000.0, dep);

            HistoricoDeVendas histVend = new HistoricoDeVendas(1, new DateTime(2021, 07, 15), 100.00, StatusDeVendas.Faturado, vend);

            _context.Departamento.Add(dep);
            _context.Vendedors.Add(vend);
            _context.HistoricoDeVendas.Add(histVend);

            _context.SaveChanges();
        }
    }
}
