using Dominio.Argumentos.Base;
using Dominio.Argumentos.Disciplina;
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
    public class ServicoDisciplinaAluno : Notifiable, IServicoDisciplinaAluno
    {
        private readonly IRepositorioDisciplinaAluno _repositorioDisciplinaAluno;

        public ServicoDisciplinaAluno(IRepositorioDisciplinaAluno repositorioDisciplinaAluno)
        {
            _repositorioDisciplinaAluno = repositorioDisciplinaAluno;
        }

        public ResponseBase Adicionar(DisciplinaAlunoRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            if (request.Id > 0) return Atualizar(request);

            var entidade = new DisciplinaAluno(request.DisciplinaId, request.AlunoId, request.Nota);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioDisciplinaAluno.Adicionar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public ResponseBase Atualizar(DisciplinaAlunoRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = _repositorioDisciplinaAluno.ObterPorId(request.Id);
            entidade.Atualizar(request.DisciplinaId, request.AlunoId, request.Nota);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioDisciplinaAluno.Editar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public IEnumerable<DisciplinaAlunoResponse> Listar()
        {
            return _repositorioDisciplinaAluno.Listar(x => x.Disciplina, x => x.Aluno).ToList().ToMap<DisciplinaAluno, DisciplinaAlunoResponse>();
        }
    }
}
