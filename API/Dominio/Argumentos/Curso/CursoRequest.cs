using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Curso
{
    public class CursoRequest : ArgumentoBase
    {
        public string Nome { get;  set; }
        public int ColegioId { get; set; }
    }
}
