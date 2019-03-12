using System;
using System.Collections.Generic;
using Dominio.Entidades;
using Infra.Persistencia;

namespace Infra.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CollegeContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CollegeContexto context)
        {
            var curso = new Curso("Analise de Sistemas")
            {
                Disciplinas = new List<Disciplina>
                {
                    new Disciplina
                    {
                        Nome = "Banco de dados",
                        Ativo = true,
                        Professor = new Professor("Professor 1", DateTime.Now.AddYears(-20), 6000),
                        DisciplinaAlunos = new List<DisciplinaAluno>
                        {
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno 1", DateTime.Now, "12304"),
                                Nota = 10
                            },
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno 2", DateTime.Now, "12341"),
                                Nota = 5
                            },
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno 3", DateTime.Now, "12342"),
                                Nota = 8.5M
                            },
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno 4", DateTime.Now, "12343"),
                                Nota = 8.5M
                            },
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno 5", DateTime.Now, "12344"),
                                Nota = 6
                            }
                        }
                    },
                    new Disciplina
                    {
                        Nome = "Logica da programacao",
                        Ativo = true,
                        Professor = new Professor("Professor 2", DateTime.Now.AddYears(-20), 7000),
                        DisciplinaAlunos = new List<DisciplinaAluno>
                        {
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno 6", DateTime.Now, "123422"),
                                Nota = 9.5M
                            },
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno 7", DateTime.Now, "123431"),
                                Nota = 3.5M
                            },
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno 8", DateTime.Now, "123443"),
                                Nota = 7
                            }
                        }
                    }
                }
            };

            var colegio = new Colegio("Colegio 1") {Cursos = new List<Curso> { curso } };
            context.Colegio.AddOrUpdate(colegio);

            curso = new Curso("Direito")
            {
                Disciplinas = new List<Disciplina>
                {
                    new Disciplina
                    {
                        Nome = "Codigo Penal",
                        Ativo = true,
                        Professor = new Professor("Professor Direito", DateTime.Now.AddYears(-40), 4000),
                        DisciplinaAlunos = new List<DisciplinaAluno>
                        {
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno Direito 1", DateTime.Now, "12304"),
                                Nota = 10
                            },
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno Direito 2", DateTime.Now, "12341"),
                                Nota = 5
                            }
                        }
                    },
                    new Disciplina
                    {
                        Nome = "Civil",
                        Ativo = true,
                        Professor = new Professor("Professor Direito 2", DateTime.Now.AddYears(-20), 7000),
                        DisciplinaAlunos = new List<DisciplinaAluno>
                        {
                            new DisciplinaAluno
                            {
                                Ativo = true,
                                Aluno = new Aluno("Aluno Direito 6", DateTime.Now, "123422"),
                                Nota = 9.5M
                            }
                        }
                    }
                }
            };

            colegio = new Colegio("Colegio 2") { Cursos = new List<Curso> { curso } };
            context.Colegio.AddOrUpdate(colegio);

            context.SaveChanges();
        }
    }
}
