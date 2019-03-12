using Dominio.Argumentos.Aluno;
using Dominio.Argumentos.Base;
using Dominio.Entidades;
using Dominio.Extensoes;
using Dominio.Interfaces.Servicos;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;
using Dominio.Argumentos.Colegio;
using Dominio.Interfaces.Repositorios;

namespace Dominio.Servicos
{
    public class ServicoColegio : Notifiable, IServicoColegio
    {
        private readonly IRepositorioColegio _repositorioColegio;

        public ServicoColegio(IRepositorioColegio repositorioColegio)
        {
            _repositorioColegio = repositorioColegio;
        }

        public ResponseBase Adicionar(ColegioRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = new Colegio(request.Nome);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioColegio.Adicionar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public ResponseBase Atualizar(ColegioRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = _repositorioColegio.ObterPorId(request.Id);
            entidade.Atualizar(request.Nome);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioColegio.Editar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public IEnumerable<ColegioResponse> Listar()
        {
            return _repositorioColegio.Listar().ToList().ToMap<Colegio, ColegioResponse>();
        }
    }
}
