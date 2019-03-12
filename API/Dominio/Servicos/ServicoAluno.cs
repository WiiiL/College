using Dominio.Argumentos.Aluno;
using Dominio.Argumentos.Base;
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
    public class ServicoAluno : Notifiable, IServicoAluno
    {
        private readonly IRepositorioAluno _repositorioAluno;

        public ServicoAluno(IRepositorioAluno repositorioAluno)
        {
            _repositorioAluno = repositorioAluno;
        }

        public ResponseBase Adicionar(AlunoRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = new Aluno(request.Nome, request.DataNascimento, request.Matricula);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioAluno.Adicionar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public ResponseBase Atualizar(AlunoRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = _repositorioAluno.ObterPorId(request.Id);
            entidade.Atualizar(request.Nome, request.DataNascimento, request.Matricula, true);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioAluno.Editar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public IEnumerable<AlunoResponse> Listar()
        {
            return _repositorioAluno.Listar().ToList().ToMap<Aluno, AlunoResponse>();
        }
    }
}
