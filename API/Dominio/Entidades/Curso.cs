using Dominio.Entidades.Base;
using System.Collections.Generic;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Dominio.Entidades
{
    public class Curso : EntidadeBase
    {
        public Curso()
        {

        }

        public Curso(string nome)
        {
            Nome = nome;
        }

        public Curso(string nome, int colegioId)
        {
            Nome = nome;
            ColegioId = colegioId;

            new AddNotifications<Curso>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Curso>(this).IfEqualsZero(x => x.ColegioId, Mensagem.X0_NAO_INFORMADO.ToFormat("Colegio"));
        }

        public void Atualizar(string nome, bool ativo)
        {
            Nome = nome;
            Ativo = ativo;

            new AddNotifications<Curso>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Curso>(this).IfEqualsZero(x => x.ColegioId, Mensagem.X0_NAO_INFORMADO.ToFormat("Colegio"));
        }

        public string Nome { get; private set; }

        public int ColegioId { get; set; }
        public virtual Colegio Colegio { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }
    }
}
