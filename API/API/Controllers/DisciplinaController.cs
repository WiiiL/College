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
    [RoutePrefix("api/disciplina")]
    public class DisciplinaController : ControllerBase<DisciplinaRequest, ResponseBase>
    {
        private readonly IServicoDisciplina _servico;

        public DisciplinaController(IUnitOfWork unitOfWork, IServicoDisciplina servico)
            : base(unitOfWork)
        {
            _servico = servico;
        }

        [HttpPost, Route("adicionar")]
        public HttpResponseMessage Adicionar(DisciplinaRequest request)
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
        public HttpResponseMessage Atualizar(DisciplinaRequest request)
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
        public HttpResponseMessage Listar(int colegioId)
        {
            try
            {
                var response = _servico.Listar(colegioId);
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet, Route("listarDisciplinas")]
        public HttpResponseMessage ListarDisciplinas(int colegioId)
        {
            try
            {
                var response = _servico.ListarDisciplinas(colegioId);
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
}