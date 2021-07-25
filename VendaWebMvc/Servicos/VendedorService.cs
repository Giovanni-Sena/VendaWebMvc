using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaWebMvc.Data;
using VendaWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendaWebMvc.Servicos.Excecao;

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
            // Utilizando o Include com a blibioteca Microsoft.EntityFrameworkCore
            return _context.Vendedores.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Vendedores.Find(id);
            _context.Vendedores.Remove(obj);
            _context.SaveChanges();
        }
        public void Atualizar(Vendedor vendedor)
        {
            if (!_context.Vendedores.Any(x => x.Id == vendedor.Id))
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
