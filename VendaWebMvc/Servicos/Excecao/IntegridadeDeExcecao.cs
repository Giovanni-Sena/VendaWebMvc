using System;

namespace VendaWebMvc.Servicos.Excecao
{
    public class IntegridadeDeExcecao : ApplicationException
    {
        public IntegridadeDeExcecao(string message) : base(message)
        {
        }
    }
}
