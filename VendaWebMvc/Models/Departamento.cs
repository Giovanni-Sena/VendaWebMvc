using System;
using System.Linq;
using System.Collections.Generic;

namespace VendaWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public void RemoveVendedor( Vendedor vendedor)
        {
            Vendedores.Remove(vendedor);
        }

        public double TotalDeVendas (DateTime inicial, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalDeVendas(inicial, final));
        }
    }
}
