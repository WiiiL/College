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
    public class ServicoDisciplina : Notifiable, IServicoDisciplina
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;
        private readonly IRepositorioDisciplinaAluno _repositorioDisciplinaAluno;

        public ServicoDisciplina(IRepositorioDisciplina repositorioDisciplina, IRepositorioDisciplinaAluno repositorioDisciplinaAluno)
        {
            _repositorioDisciplina = repositorioDisciplina;
            _repositorioDisciplinaAluno = repositorioDisciplinaAluno;
        }

        public ResponseBase Adicionar(DisciplinaRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = new Disciplina(request.Nome, request.CursoId, request.ProfessorId);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioDisciplina.Adicionar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public ResponseBase Atualizar(DisciplinaRequest request)
        {
            var entidade = _repositorioDisciplina.ObterPorId(request.Id);
            entidade.Atualizar(request.Nome, request.CursoId, request.ProfessorId);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioDisciplina.Editar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public IEnumerable<DisciplinaResponse> Listar(int colegioId)
        {
            return _repositorioDisciplina.ListarPor(x=>x.Curso.ColegioId == colegioId, x => x.Curso, x => x.Professor).ToList().ToMap<Disciplina, DisciplinaResponse>();
        }

        public IEnumerable<DisciplinaFullResponse> ListarDisciplinas(int colegioId)
        {
            var retorno = _repositorioDisciplina.ListarPor(x=>x.Curso.ColegioId == colegioId, x => x.Curso, x => x.Professor).ToList()
                .ToMap<Disciplina, DisciplinaFullResponse>();

            var disciplinaFullResponses = retorno as DisciplinaFullResponse[] ?? retorno.ToArray();
            foreach (var item in disciplinaFullResponses)
            {
                item.DisciplinaAlunos = _repositorioDisciplinaAluno.ListarPor(x => x.DisciplinaId == item.Id, x => x.Aluno).ToList().ToMap<DisciplinaAluno, DisciplinaAlunoResponse>();
            }

            return disciplinaFullResponses;
        }
    }
}
