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

        public async Task<List<Vendedor>> BuscarTodosAsync()
        {
            return await _context.Vendedores.ToListAsync();
        }

        public async Task InsertAsync(Vendedor insertVendedor) // Trocado o void por Task, tornando a Async
        {
            _context.Add(insertVendedor); // Salva em memória
            await _context.SaveChangesAsync(); // Realiza a conexão com o DB
        }

        public async Task<Vendedor> EncontrarPorIdAsync(int id)
        {
            // Utilizando o Include com a blibioteca Microsoft.EntityFrameworkCore
            return await _context.Vendedores.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoverAsync(int id)
        {
            var obj = await _context.Vendedores.FindAsync(id);
            _context.Vendedores.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarAsync(Vendedor vendedor)
        {
            if (!await _context.Vendedores.AnyAsync(x => x.Id == vendedor.Id))
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(vendedor);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
