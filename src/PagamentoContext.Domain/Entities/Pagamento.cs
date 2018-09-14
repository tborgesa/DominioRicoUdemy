using Flunt.Validations;
using PagamentoContext.Domain.ValueObjects;
using PagamentoContext.Shared.Entities;
using System;

namespace PagamentoContext.Domain.Entities
{
    public abstract class Pagamento : Entity
    {
        public Pagamento(DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago, string pagador, Documento documento,
            Endereco endereco, Email email)
        {
            Numero = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            DataPagamento = dataPagamento;
            DataExpiracao = dataExpiracao;
            Total = total;
            TotalPago = totalPago;
            Pagador = pagador;
            Documento = documento;
            Endereco = endereco;
            Email = email;

            AddNotifications(new Contract()
                .IsGreaterThan(Total, 0, "Pagamento.Total", "O valor do pagamento deve ser maior que zero.")
                .IsGreaterOrEqualsThan(TotalPago, Total, "Pagamento.TotalPago", "O valor pago não pode ser menor que o valor do pagamento.")
                );
        }

        public string Numero { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public string Pagador { get; private set; }
        public Documento Documento { get; private set; }
        public Endereco Endereco { get; private set; }
        public Email Email { get; private set; }
    }
}
