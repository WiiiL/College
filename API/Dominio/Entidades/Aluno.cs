using Dominio.Entidades.Base;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace Dominio.Entidades
{
    public class Aluno : EntidadeBase
    {
        public Aluno()
        {

        }

        public Aluno(string nome, DateTime dataNascimento, string matricula)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Matricula = matricula;

            new AddNotifications<Aluno>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Aluno>(this).IfNull(x => x.DataNascimento, Mensagem.X0_NAO_INFORMADO.ToFormat("Data Nascimento"));
            new AddNotifications<Aluno>(this).IfNullOrWhiteSpace(x => x.Matricula, Mensagem.X0_NAO_INFORMADO.ToFormat("Matricula"));
        }

        public void Atualizar(string nome, DateTime dataNascimento, string matricula, bool ativo)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Matricula = matricula;
            Ativo = ativo;

            new AddNotifications<Aluno>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Aluno>(this).IfNull(x => x.DataNascimento, Mensagem.X0_NAO_INFORMADO.ToFormat("Data Nascimento"));
            new AddNotifications<Aluno>(this).IfNullOrWhiteSpace(x => x.Matricula, Mensagem.X0_NAO_INFORMADO.ToFormat("Matricula"));
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Matricula { get; private set; }
    }
}
