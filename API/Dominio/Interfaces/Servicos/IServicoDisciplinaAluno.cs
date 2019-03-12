using System.Collections.Generic;
using Dominio.Argumentos.Base;
using Dominio.Argumentos.Disciplina;
using Dominio.Interfaces.Servicos.Base;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoDisciplinaAluno : IServicoBase<DisciplinaAlunoRequest, ResponseBase>
    {
        IEnumerable<DisciplinaAlunoResponse> Listar();
    }
}
