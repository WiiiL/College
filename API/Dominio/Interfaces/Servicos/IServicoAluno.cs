using Dominio.Argumentos.Aluno;
using Dominio.Argumentos.Base;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoAluno : IServicoBase<AlunoRequest, ResponseBase>
    {
        IEnumerable<AlunoResponse> Listar();
    }
}
