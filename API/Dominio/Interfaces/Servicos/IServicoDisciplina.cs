using Dominio.Argumentos.Base;
using Dominio.Argumentos.Disciplina;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoDisciplina : IServicoBase<DisciplinaRequest, ResponseBase>
    {
        IEnumerable<DisciplinaResponse> Listar(int colegioId);
        IEnumerable<DisciplinaFullResponse> ListarDisciplinas(int colegioId);
    }
}
