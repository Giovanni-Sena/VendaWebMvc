using System;
using System.Collections.Generic;
using System.Linq;

namespace VendaWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<HistoricoDeVendas> Vendas { get; set; } = new List<HistoricoDeVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string name, DateTime birthDate, string email, double salary, Departamento departamento)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Salary = salary;
            Departamento = departamento;
        }

        public void AddVenda(HistoricoDeVendas histVendas)
        {
            Vendas.Add(histVendas);
        }

        public void RemoveVenda( HistoricoDeVendas histVendas)
        {
            Vendas.Remove(histVendas);
        }

        public double TotalDeVendas( DateTime inicial, DateTime final)
        {
            return Vendas.Where(histVendas => histVendas.Date >= inicial && histVendas.Date <= final).Sum( histVendas => histVendas.Amount);
        }
    }
}
