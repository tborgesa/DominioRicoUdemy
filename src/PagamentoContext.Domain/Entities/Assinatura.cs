using System;
using System.Collections.Generic;

namespace PagamentoContext.Domain.Entities
{
    public class Assinatura
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public bool Ativo { get; set; }
        public List<Pagamento> Pagamentos { get; set; }
    }
}
