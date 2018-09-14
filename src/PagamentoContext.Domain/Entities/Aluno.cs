using Flunt.Validations;
using PagamentoContext.Domain.ValueObjects;
using PagamentoContext.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PagamentoContext.Domain.Entities
{
    public class Aluno : Entity
    {
        private IList<Assinatura> _assinaturas;

        public Aluno(Nome nome, Documento documento, Email email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            _assinaturas = new List<Assinatura>();

            AddNotifications(nome, documento, email);
        }

        public Nome Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas => _assinaturas.ToArray();

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            var assinaturaAtiva = false;
            foreach (var a in _assinaturas)
                if (a.Ativo) assinaturaAtiva = true;

            AddNotifications(new Contract()
                .IsFalse(assinaturaAtiva, "Estudante.Assinatura", "Você já tem uma assinatura ativa")
                .IsGreaterThan(assinatura.Pagamentos.Count, 0, "Estudante.Assinatura.Pagamento", "Assinatura deve conter pelo menos um pagamento.")
                );

            if (Valid)
                _assinaturas.Add(assinatura);
        }
    }
}
