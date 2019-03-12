using Dominio.Argumentos.Base;
using Dominio.Argumentos.Disciplina;
using Dominio.Interfaces.Servicos;
using Infra.Transacao;
using System;
using System.Net.Http;
using System.Web.Http;
using Utilidade.ControllerBase;

namespace API.Controllers
{
    [RoutePrefix("api/disciplinaAluno")]
    public class DisciplinaAlunoController : ControllerBase<DisciplinaAlunoRequest, ResponseBase>
    {
        private readonly IServicoDisciplinaAluno _servico;

        public DisciplinaAlunoController(IUnitOfWork unitOfWork, IServicoDisciplinaAluno servico)
            : base(unitOfWork)
        {
            _servico = servico;
        }

        [HttpPost, Route("adicionar")]
        public HttpResponseMessage Adicionar(DisciplinaAlunoRequest request)
        {
            try
            {
                var response = _servico.Adicionar(request);
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpPut, Route("atualizar")]
        public HttpResponseMessage Atualizar(DisciplinaAlunoRequest request)
        {
            try
            {
                var response = _servico.Atualizar(request);
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet, Route("listar")]
        public HttpResponseMessage Listar()
        {
            try
            {
                var response = _servico.Listar();
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
}