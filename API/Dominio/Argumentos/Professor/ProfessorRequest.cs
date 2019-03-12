using System;
using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Professor
{
    public class ProfessorRequest : ArgumentoBase
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }
    }
}
