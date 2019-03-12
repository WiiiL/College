using Dominio.Entidades.Base;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Dominio.Entidades
{
    public class DisciplinaAluno : EntidadeBase
    {
        public int DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public decimal Nota { get; set; }

        public DisciplinaAluno()
        {

        }

        public DisciplinaAluno(int disciplinaId, int alunoId, decimal nota)
        {
            DisciplinaId = disciplinaId;
            AlunoId = alunoId;
            Nota = nota;

            new AddNotifications<DisciplinaAluno>(this).IfEqualsZero(x => x.DisciplinaId, Mensagem.X0_NAO_INFORMADO.ToFormat("Disciplina"));
            new AddNotifications<DisciplinaAluno>(this).IfEqualsZero(x => x.AlunoId, Mensagem.X0_NAO_INFORMADO.ToFormat("Aluno"));
        }

        public void Atualizar(int disciplinaId, int alunoId, decimal nota)
        {
            DisciplinaId = disciplinaId;
            AlunoId = alunoId;
            Nota = nota;

            new AddNotifications<DisciplinaAluno>(this).IfEqualsZero(x => x.DisciplinaId, Mensagem.X0_NAO_INFORMADO.ToFormat("Disciplina"));
            new AddNotifications<DisciplinaAluno>(this).IfEqualsZero(x => x.AlunoId, Mensagem.X0_NAO_INFORMADO.ToFormat("Aluno"));
        }
    }
}
