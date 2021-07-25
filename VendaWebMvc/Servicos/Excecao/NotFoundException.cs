using System;

namespace VendaWebMvc.Servicos.Excecao
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
