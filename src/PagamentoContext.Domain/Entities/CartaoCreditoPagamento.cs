using System;
using System.Collections.Generic;
using System.Text;

namespace PagamentoContext.Domain.Entities
{
    public class CartaoCreditoPagamento : Pagamento
    {
        public CartaoCreditoPagamento(string nomeTitular, string numero, string numeroUltimaTransacao, DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago, string pagador, string documento, string endereco, string email) : base(dataPagamento, dataExpiracao, total, totalPago, pagador, documento, endereco, email)
        {
            NomeTitular = nomeTitular;
            Numero = numero;
            NumeroUltimaTransacao = numeroUltimaTransacao;
        }

        public string NomeTitular { get; private set; }
        public string Numero { get; private set; }
        public string NumeroUltimaTransacao { get; private set; }
    }
}
