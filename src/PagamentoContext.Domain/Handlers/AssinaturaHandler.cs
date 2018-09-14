using System;
using Flunt.Notifications;
using PagamentoContext.Domain.Commands;
using PagamentoContext.Shared.Commands;
using PagamentoContext.Shared.Handlers;
using PagamentoContext.Domain.Repositories;
using PagamentoContext.Domain.ValueObjects;
using PagamentoContext.Domain.Entities;
using PagamentoContext.Domain.Services;

namespace PagamentoContext.Domain.Handlers
{
    public class AssinaturaHandler : 
        Notifiable,
        IHandler<CreateAssinaturaBoletoCommand>,
        IHandler<CreateAssinaturaPayPalCommand>,
        IHandler<CreateAssinaturaCartaoCreditoCommand>
    {
        private readonly IAlunoRepository _repository;
        private readonly IEmailService _emailService;

        public AssinaturaHandler(IAlunoRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateAssinaturaBoletoCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            // Verificar se Documento já está cadastrado
            if (_repository.DocumentoExiste(command.Documento))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se E-mail já está cadastrado
            if (_repository.EmailExiste(command.Documento))
                AddNotification("Email", "Este Email já está em uso");

            // Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.UltimoNome);
            var documento = new Documento(command.Documento, Enums.TipoDocumento.Cpf);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Logradouro, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Cep);

            // Gerar as Entidades
            var aluno = new Aluno(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new BoletoPagamento(
                command.CodigoBarra,
                command.NossoNumero,
                command.DataPagamento,
                command.DataExpiracao,
                command.Total,
                command.TotalPago,
                command.Pagador,
                new Documento(command.DocumentoPagador, command.TipoDocumentoPagador),
                endereco,
                new Email(command.EmailPagador));

            // Relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            aluno.AdicionarAssinatura(assinatura);

            // Agrupar as Validações
            AddNotifications(aluno, assinatura, pagamento);

            // Salvar as Informações
            _repository.CriarAssinatura(aluno);

            // Enviar E-mail de boas vindas
            _emailService.Enviar(aluno.Nome.ToString(), aluno.Email.Endereco, "Bem Vindo ao balta.io", "Sua assinatura foi criada.");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreateAssinaturaPayPalCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            // Verificar se Documento já está cadastrado
            if (_repository.DocumentoExiste(command.Documento))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se E-mail já está cadastrado
            if (_repository.EmailExiste(command.Documento))
                AddNotification("Email", "Este Email já está em uso");

            // Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.UltimoNome);
            var documento = new Documento(command.Documento, Enums.TipoDocumento.Cpf);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Logradouro, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Cep);

            // Gerar as Entidades
            var aluno = new Aluno(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new PayPalPagamento(
                command.CodigoTransacao,
                command.DataPagamento,
                command.DataExpiracao,
                command.Total,
                command.TotalPago,
                command.Pagador,
                new Documento(command.DocumentoPagador, command.TipoDocumentoPagador),
                endereco,
                new Email(command.EmailPagador));

            // Relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            aluno.AdicionarAssinatura(assinatura);

            // Agrupar as Validações
            AddNotifications(aluno, assinatura, pagamento);

            // Salvar as Informações
            _repository.CriarAssinatura(aluno);

            // Enviar E-mail de boas vindas
            _emailService.Enviar(aluno.Nome.ToString(), aluno.Email.Endereco, "Bem Vindo ao balta.io", "Sua assinatura foi criada.");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreateAssinaturaCartaoCreditoCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            // Verificar se Documento já está cadastrado
            if (_repository.DocumentoExiste(command.Documento))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se E-mail já está cadastrado
            if (_repository.EmailExiste(command.Documento))
                AddNotification("Email", "Este Email já está em uso");

            // Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.UltimoNome);
            var documento = new Documento(command.Documento, Enums.TipoDocumento.Cpf);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Logradouro, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Cep);

            // Gerar as Entidades
            var aluno = new Aluno(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new CartaoCreditoPagamento(
                command.NomeTitular,
                command.NumeroTransacao,
                command.NumeroUltimaTransacao,
                command.DataPagamento,
                command.DataExpiracao,
                command.Total,
                command.TotalPago,
                command.Pagador,
                new Documento(command.DocumentoPagador, command.TipoDocumentoPagador),
                endereco,
                new Email(command.EmailPagador));

            // Relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            aluno.AdicionarAssinatura(assinatura);

            // Agrupar as Validações
            AddNotifications(aluno, assinatura, pagamento);

            // Salvar as Informações
            _repository.CriarAssinatura(aluno);

            // Enviar E-mail de boas vindas
            _emailService.Enviar(aluno.Nome.ToString(), aluno.Email.Endereco, "Bem Vindo ao balta.io", "Sua assinatura foi criada.");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
