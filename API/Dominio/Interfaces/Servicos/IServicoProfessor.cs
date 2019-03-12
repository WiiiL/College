using Dominio.Argumentos.Base;
using Dominio.Argumentos.Professor;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoProfessor : IServicoBase<ProfessorRequest, ResponseBase>
    {
        IEnumerable<ProfessorResponse> Listar();
    }
}
