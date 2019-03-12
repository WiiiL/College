using Dominio.Entidades.Base;
using System.Collections.Generic;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Dominio.Entidades
{
    public class Disciplina : EntidadeBase
    {
        public Disciplina()
        {

        }

        public Disciplina(string nome, int cursoId, int professorId)
        {
            Nome = nome;
            CursoId = cursoId;
            ProfessorId = professorId;

            new AddNotifications<Disciplina>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Disciplina>(this).IfEqualsZero(x => x.ProfessorId, Mensagem.X0_NAO_INFORMADO.ToFormat("Professor"));
            new AddNotifications<Disciplina>(this).IfEqualsZero(x => x.CursoId, Mensagem.X0_NAO_INFORMADO.ToFormat("Curso"));
        }

        public void Atualizar(string nome, int cursoId, int professorId)
        {
            Nome = nome;
            CursoId = cursoId;
            ProfessorId = professorId;

            new AddNotifications<Disciplina>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Disciplina>(this).IfEqualsZero(x => x.ProfessorId, Mensagem.X0_NAO_INFORMADO.ToFormat("Professor"));
            new AddNotifications<Disciplina>(this).IfEqualsZero(x => x.CursoId, Mensagem.X0_NAO_INFORMADO.ToFormat("Curso"));
        }

        public string Nome { get; set; }

        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        public ICollection<DisciplinaAluno> DisciplinaAlunos { get; set; }

    }
}
