using Infra.Persistencia;

namespace Infra.Transacao
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CollegeContexto _context;

        public UnitOfWork(CollegeContexto context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
