using System.Data.Entity.ModelConfiguration;

namespace Infra.Persistencia.Map
{
    public class MapProfessor : EntityTypeConfiguration<Dominio.Entidades.Professor>
    {
        public MapProfessor()
        {
            ToTable("Professor");

            Property(p => p.Id).HasColumnName("ProfessorId");
            Property(p => p.Nome).HasColumnName("Nome").IsRequired();
            Property(p => p.DataNascimento).HasColumnName("DataNascimento").IsRequired();
            Property(p => p.Salario).HasColumnName("Salario").IsRequired();
        }
    }
}