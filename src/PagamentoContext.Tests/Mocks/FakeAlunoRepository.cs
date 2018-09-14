using System;
using PagamentoContext.Domain.Entities;
using PagamentoContext.Domain.Repositories;

namespace PagamentoContext.Tests.Mocks
{
    public class FakeAlunoRepository : IAlunoRepository
    {
        public void CriarAssinatura(Aluno aluno)
        {
        }

        public bool DocumentoExiste(string documento)
        {
            if (documento == "99999999999")
                return true;

            return false;
        }

        public bool EmailExiste(string email)
        {
            if (email == "hello@balta.io")
                return true;

            return false;
        }
    }
}
