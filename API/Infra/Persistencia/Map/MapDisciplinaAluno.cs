using System.Data.Entity.ModelConfiguration;

namespace Infra.Persistencia.Map
{
    public class MapDisciplinaAluno : EntityTypeConfiguration<Dominio.Entidades.DisciplinaAluno>
    {
        public MapDisciplinaAluno()
        {
            ToTable("DisciplinaAluno");

            Property(p => p.Id).HasColumnName("DisciplinaAlunoId");
            Property(p => p.Nota).HasColumnName("Nota").IsRequired();
            Property(p => p.DisciplinaId).HasColumnAnnotation("ForeignKey", "DisciplinaId").IsRequired();
            Property(p => p.AlunoId).HasColumnAnnotation("ForeignKey", "AlunoId").IsRequired();
        }
    }
}