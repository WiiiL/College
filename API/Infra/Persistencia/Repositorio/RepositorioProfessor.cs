using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Persistencia.Repositorio.Base;

namespace Infra.Persistencia.Repositorio
{
    public class RepositorioProfessor : RepositorioBase<Professor, int>, IRepositorioProfessor
    {
        protected readonly CollegeContexto _context;

        public RepositorioProfessor(CollegeContexto context)
            : base(context)
        {
            _context = context;
        }
    }
}
