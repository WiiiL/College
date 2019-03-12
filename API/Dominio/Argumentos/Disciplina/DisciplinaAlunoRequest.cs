using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Disciplina
{
    public class DisciplinaAlunoRequest : ArgumentoBase
    {
        public int DisciplinaId { get; set; }
        public int AlunoId { get; set; }
        public decimal Nota { get; set; }
    }
}
