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
        public Endereco Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas => _assinaturas.ToArray();

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            var assinaturaAtiva = false;
            foreach (var a in _assinaturas)
                if (a.Ativo) assinaturaAtiva = true;

            //Duas maneiras de fazer o mesma validação
            //AddNotifications(new Contract().IsFalse(assinaturaAtiva, "Estudante.Assinatura", "Você já tem uma assinatura ativa"));
            if (assinaturaAtiva)
                AddNotification("Estudante.Assinatura", "Você já tem uma assinatura ativa");

            if (Valid)
                _assinaturas.Add(assinatura);
        }
    }
}
