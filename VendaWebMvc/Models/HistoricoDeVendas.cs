using System;
using VendaWebMvc.Models.Enums;

namespace VendaWebMvc.Models
{
    public class HistoricoDeVendas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public StatusDeVendas Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public HistoricoDeVendas()
        {
        }

        public HistoricoDeVendas(int id, DateTime date, double amount, StatusDeVendas status, Vendedor vendedor)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
