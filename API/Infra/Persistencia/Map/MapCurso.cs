using System.Data.Entity.ModelConfiguration;

namespace Infra.Persistencia.Map
{
    public class MapCurso : EntityTypeConfiguration<Dominio.Entidades.Curso>
    {
        public MapCurso()
        {
            ToTable("Curso");

            Property(p => p.Id).HasColumnName("CursoId");
            Property(p => p.Nome).HasColumnName("Nome").IsRequired();
        }
    }
}