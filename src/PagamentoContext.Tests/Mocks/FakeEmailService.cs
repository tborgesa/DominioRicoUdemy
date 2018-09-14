using System;
using PagamentoContext.Domain.Services;

namespace PagamentoContext.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Enviar(string para, string email, string assunto, string corpo)
        {
        }
    }
}
