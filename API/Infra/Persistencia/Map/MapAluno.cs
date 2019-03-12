using System.Data.Entity.ModelConfiguration;

namespace Infra.Persistencia.Map
{
    public class MapAluno : EntityTypeConfiguration<Dominio.Entidades.Aluno>
    {
        public MapAluno()
        {
            ToTable("Aluno");

            Property(p => p.Id).HasColumnName("AlunoId");
            Property(p => p.Nome).HasColumnName("Nome").IsRequired();
            Property(p => p.DataNascimento).HasColumnName("DataNascimento").IsRequired();
            Property(p => p.Matricula).HasColumnName("Matricula").IsRequired();
        }
    }
}