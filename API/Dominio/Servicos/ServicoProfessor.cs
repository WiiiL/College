using Dominio.Argumentos.Base;
using Dominio.Argumentos.Professor;
using Dominio.Entidades;
using Dominio.Extensoes;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Servicos
{
    public class ServicoProfessor : Notifiable, IServicoProfessor
    {
        private readonly IRepositorioProfessor _repositorioProfessor;

        public ServicoProfessor(IRepositorioProfessor repositorioProfessor)
        {
            _repositorioProfessor = repositorioProfessor;
        }

        public ResponseBase Adicionar(ProfessorRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = new Professor(request.Nome, request.DataNascimento, request.Salario);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioProfessor.Adicionar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public ResponseBase Atualizar(ProfessorRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = _repositorioProfessor.ObterPorId(request.Id);
            entidade.Atualizar(request.Nome, request.DataNascimento, request.Salario);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioProfessor.Editar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public IEnumerable<ProfessorResponse> Listar()
        {
            return _repositorioProfessor.Listar().ToList().ToMap<Professor, ProfessorResponse>();
        }
    }
}

