using Dominio.Argumentos.Base;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;
using Dominio.Argumentos.Colegio;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoColegio : IServicoBase<ColegioRequest, ResponseBase>
    {
        IEnumerable<ColegioResponse> Listar();
    }
}

