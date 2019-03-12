using Dominio.Entidades.Base;
using System;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Dominio.Entidades
{
    public class Professor : EntidadeBase
    {
        public Professor()
        {

        }

        public Professor(string nome, DateTime dataNascimento, decimal salario)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Salario = salario;

            new AddNotifications<Professor>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Professor>(this).IfNull(x => x.DataNascimento, Mensagem.X0_NAO_INFORMADO.ToFormat("DataNascimento"));
        }

        public void Atualizar(string nome, DateTime dataNascimento, decimal salario)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Salario = salario;

            new AddNotifications<Professor>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Professor>(this).IfNull(x => x.DataNascimento, Mensagem.X0_NAO_INFORMADO.ToFormat("DataNascimento"));
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public decimal Salario { get; private set; }
    }
}
