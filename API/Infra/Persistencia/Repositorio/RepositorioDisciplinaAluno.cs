using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Persistencia.Repositorio.Base;

namespace Infra.Persistencia.Repositorio
{
    public class RepositorioDisciplinaAluno : RepositorioBase<DisciplinaAluno, int>, IRepositorioDisciplinaAluno
    {
        protected readonly CollegeContexto _context;

        public RepositorioDisciplinaAluno(CollegeContexto context)
            : base(context)
        {
            _context = context;
        }
    }
}