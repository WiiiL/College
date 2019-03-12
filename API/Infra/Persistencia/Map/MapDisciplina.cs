using System.Data.Entity.ModelConfiguration;

namespace Infra.Persistencia.Map
{
    public class MapDisciplina : EntityTypeConfiguration<Dominio.Entidades.Disciplina>
    {
        public MapDisciplina()
        {
            ToTable("Disciplina");

            Property(p => p.Id).HasColumnName("DisciplinaId");
            Property(p => p.Nome).HasColumnName("Nome").IsRequired();
            Property(p => p.CursoId).HasColumnAnnotation("ForeignKey", "Curso").IsRequired();
            Property(p => p.ProfessorId).HasColumnAnnotation("ForeignKey", "Professor").IsRequired();
        }
    }
}