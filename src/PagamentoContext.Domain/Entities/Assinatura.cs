using Flunt.Validations;
using PagamentoContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PagamentoContext.Domain.Entities
{
    public class Assinatura : Entity
    {
        private IList<Pagamento> _pagamentos;

        public Assinatura(DateTime? dataExpiracao)
        {
            DataCriacao = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            DataExpiracao = dataExpiracao;
            Ativo = true;
            _pagamentos = new List<Pagamento>();
        }

        public DateTime DataCriacao { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public DateTime? DataExpiracao { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<Pagamento> Pagamentos => _pagamentos.ToArray();

        public void AdicionarPagamento(Pagamento pagamento)
        {
            AddNotifications(new Contract()
                .IsLowerThan(pagamento.DataPagamento, DateTime.Now, "Assinatura.Pagamentos", "A data do pagamento não pode ser futura.")
                );

            _pagamentos.Add(pagamento);
        }

        public void Inativar()
        {
            Ativo = false;
            DataUltimaAtualizacao = DateTime.Now;
        }
    }
}
