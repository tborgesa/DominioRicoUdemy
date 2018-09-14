using PagamentoContext.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace PagamentoContext.Domain.Queries
{
    public static class AlunoQueries
    {
        public static Expression<Func<Aluno,bool>> GetAluno(string documento)
        {
            return a => a.Documento.Numero == documento;
        }
    }
}
