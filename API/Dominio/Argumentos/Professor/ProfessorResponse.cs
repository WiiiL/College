using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Professor
{
    public class ProfessorResponse : ArgumentoBase
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public decimal Salario { get; set; }
    }
}
