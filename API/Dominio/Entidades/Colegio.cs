using Dominio.Entidades.Base;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Colegio : EntidadeBase
    {
        public string Nome { get; set; }
        public ICollection<Curso> Cursos { get; set; }

        public Colegio()
        {

        }

        public Colegio(string nome)
        {
            Nome = nome;

            new AddNotifications<Colegio>(this).IfNull(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
        }

        internal void Atualizar(string nome)
        {
            Nome = nome;

            new AddNotifications<Colegio>(this).IfNull(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
        }
    }
}
