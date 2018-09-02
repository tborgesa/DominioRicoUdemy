using System;

namespace PagamentoContext.Domain.Entities
{
    public abstract class Pagamento
    {
        public Pagamento(DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago, string pagador, string documento, string endereco, string email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,10).ToUpper();
            DataPagamento = dataPagamento;
            DataExpiracao = dataExpiracao;
            Total = total;
            TotalPago = totalPago;
            Pagador = pagador;
            Documento = documento;
            Endereco = endereco;
            Email = email;
        }

        public string Number { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public string Pagador { get; private set; }
        public string Documento { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }
    }
}
