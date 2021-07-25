using System;

namespace VendaWebMvc.Servicos.Excecao
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}
