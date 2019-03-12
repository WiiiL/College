using Dominio.Argumentos.Aluno;
using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Disciplina
{
    public class DisciplinaAlunoResponse : ArgumentoBase
    {
        public int DisciplinaId { get; set; }
        public DisciplinaResponse Disciplina { get; set; }

        public int AlunoId { get; set; }
        public AlunoResponse Aluno { get; set; }

        public decimal Nota { get; set; }
    }
}
