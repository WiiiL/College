using System;
using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Aluno
{
    public class AlunoRequest : ArgumentoBase
    {
        public string Nome { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Matricula { get;  set; }
    }
}
