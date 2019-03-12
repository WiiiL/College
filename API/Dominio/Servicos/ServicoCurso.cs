using Dominio.Argumentos.Base;
using Dominio.Argumentos.Curso;
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
    public class ServicoCurso : Notifiable, IServicoCurso
    {
        private readonly IRepositorioCurso _repositorioCurso;

        public ServicoCurso(IRepositorioCurso repositorioCurso)
        {
            _repositorioCurso = repositorioCurso;
        }

        public ResponseBase Adicionar(CursoRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = new Curso(request.Nome, request.ColegioId);
            AddNotifications(entidade);

            if (IsInvalid()) return null;
            _repositorioCurso.Adicionar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public ResponseBase Atualizar(CursoRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = _repositorioCurso.ObterPorId(request.Id);
            entidade.Atualizar(request.Nome, true);
            AddNotifications(entidade);

            if (IsInvalid()) return null;
            _repositorioCurso.Editar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public IEnumerable<CursoResponse> Listar(int colegioId)
        {
            return _repositorioCurso.ListarPor(x => x.ColegioId == colegioId).ToList().ToMap<Curso, CursoResponse>();
        }

        public List<Dashboard> Dashboard(int colegioId)
        {
            var lista = new List<Dashboard>();
            var cursos = _repositorioCurso.ListarPor(x => x.ColegioId == colegioId, x => x.Disciplinas.Select(y => y.DisciplinaAlunos));
            foreach (var curso in cursos)
            {
                var retorno = new Dashboard
                {
                    NomeCurso = curso.Nome,
                    QtdDisciplinas = curso.Disciplinas.Count
                };

                foreach (var disciplina in curso.Disciplinas)
                {
                    var alunos = disciplina.DisciplinaAlunos.Count(x => x.Disciplina.CursoId == disciplina.CursoId);
                    retorno.QtdAlunos += alunos;
                    retorno.SumNota += alunos > 0 ? disciplina.DisciplinaAlunos.Sum(x => x.Nota) / alunos : 0;
                }

                retorno.MediaNota = retorno.QtdDisciplinas > 0 ? retorno.SumNota / retorno.QtdDisciplinas : 0;
                lista.Add(retorno);
            }

            return lista;
        }
    }
}
