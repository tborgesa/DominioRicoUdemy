using System.Collections.Generic;

namespace PagamentoContext.Domain.Entities
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public List<Assinatura> Assinaturas { get; set; }
        public string Endereco { get; set; }
    }
}
