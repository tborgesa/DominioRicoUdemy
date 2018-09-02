using System;

namespace PagamentoContext.Domain.Entities
{
    public abstract class Pagamento
    {
        public string Number { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataExpiracao { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Pagador { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
    }

    public class BoletoPagamento : Pagamento
    {
        public string CodigoBarra { get; set; }
        public string NossoNumero { get; set; }
    }

    public class CartaoCreditoPagamento : Pagamento
    {
        public string NomeTitular { get; set; }
        public string Numero { get; set; }
        public string NumeroUltimaTransacao { get; set; }
    }

    public class PayPalPagamento : Pagamento
    {
        public string CodigoTransacao { get; set; }
    }
}
