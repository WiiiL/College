using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Persistencia.Repositorio.Base;

namespace Infra.Persistencia.Repositorio
{
    public class RepositorioColegio : RepositorioBase<Colegio, int>, IRepositorioColegio
    {
        protected readonly CollegeContexto _context;

        public RepositorioColegio(CollegeContexto context)
            : base(context)
        {
            _context = context;
        }
    }
}
