using Dominio.Argumentos.Base;
using Dominio.Argumentos.Colegio;
using Dominio.Interfaces.Servicos;
using Infra.Transacao;
using System;
using System.Net.Http;
using System.Web.Http;
using Utilidade.ControllerBase;

namespace API.Controllers
{
    [RoutePrefix("api/colegio")]
    public class ColegioController : ControllerBase<ColegioRequest, ResponseBase>
    {
        private readonly IServicoColegio _servico;

        public ColegioController(IUnitOfWork unitOfWork, IServicoColegio servico)
            : base(unitOfWork)
        {
            _servico = servico;
        }

        [HttpPost, Route("adicionar")]
        public HttpResponseMessage Adicionar(ColegioRequest request)
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
        public HttpResponseMessage Atualizar(ColegioRequest request)
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