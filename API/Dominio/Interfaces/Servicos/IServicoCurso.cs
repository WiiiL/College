using Dominio.Argumentos.Base;
using Dominio.Argumentos.Curso;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoCurso : IServicoBase<CursoRequest, ResponseBase>
    {
        IEnumerable<CursoResponse> Listar(int colegioId);
        List<Dashboard> Dashboard(int colegioId);
    }
}
