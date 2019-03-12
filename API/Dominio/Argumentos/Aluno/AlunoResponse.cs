using Dominio.Argumentos.Base;
using Dominio.Argumentos.Disciplina;
using System.Collections.Generic;

namespace Dominio.Argumentos.Aluno
{
    public class AlunoResponse : ArgumentoBase
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Matricula { get; set; }

        public IEnumerable<DisciplinaAlunoResponse> DisciplinaAlunos { get; set; }
    }
}
