using Dominio.Argumentos.Base;
using Dominio.Argumentos.Curso;
using Dominio.Interfaces.Servicos;
using Infra.Transacao;
using System;
using System.Net.Http;
using System.Web.Http;
using Utilidade.ControllerBase;

namespace API.Controllers
{
    [RoutePrefix("api/curso")]
    public class CursoController : ControllerBase<CursoRequest, ResponseBase>
    {
        private readonly IServicoCurso _servico;

        public CursoController(IUnitOfWork unitOfWork, IServicoCurso servico)
            : base(unitOfWork)
        {
            _servico = servico;
        }

        [HttpPost, Route("adicionar")]
        public HttpResponseMessage Adicionar(CursoRequest request)
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
        public HttpResponseMessage Atualizar(CursoRequest request)
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

        [HttpGet, Route("dashboard")]
        public HttpResponseMessage Dashboard(int colegioId)
        {
            try
            {
                var response = _servico.Dashboard(colegioId);
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
}
