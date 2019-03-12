using System.Collections.Generic;
using Dominio.Argumentos.Base;
using Dominio.Argumentos.Curso;
using Dominio.Argumentos.Professor;

namespace Dominio.Argumentos.Disciplina
{
    public class DisciplinaResponse : ArgumentoBase
    {
        public string Nome { get; set; }

        public int ProfessorId { get; set; }
        public ProfessorResponse Professor { get; set; }

        public int CursoId { get; set; }
        public CursoResponse Curso { get; set; }
    }

    public class DisciplinaFullResponse : ArgumentoBase
    {
        public string Nome { get; set; }

        public int ProfessorId { get; set; }
        public ProfessorResponse Professor { get; set; }

        public int CursoId { get; set; }
        public CursoResponse Curso { get; set; }
        public IEnumerable<DisciplinaAlunoResponse> DisciplinaAlunos { get; set; }
    }

}
