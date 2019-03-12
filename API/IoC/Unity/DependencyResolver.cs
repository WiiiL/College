using AutoMapper;
using Dominio.Argumentos.Aluno;
using Dominio.Argumentos.Colegio;
using Dominio.Argumentos.Curso;
using Dominio.Argumentos.Disciplina;
using Dominio.Argumentos.Professor;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Repositorios.Base;
using Dominio.Interfaces.Servicos;
using Dominio.Interfaces.Servicos.Base;
using Dominio.Servicos;
using Infra.Persistencia;
using Infra.Persistencia.Repositorio;
using Infra.Transacao;
using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;

namespace IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, CollegeContexto>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            container.RegisterType(typeof(IServicoBase<,>), typeof(IServicoBase<,>));
            container.RegisterType<IServicoCurso, ServicoCurso>(new HierarchicalLifetimeManager());
            container.RegisterType<IServicoAluno, ServicoAluno>(new HierarchicalLifetimeManager());
            container.RegisterType<IServicoProfessor, ServicoProfessor>(new HierarchicalLifetimeManager());
            container.RegisterType<IServicoDisciplina, ServicoDisciplina>(new HierarchicalLifetimeManager());
            container.RegisterType<IServicoDisciplinaAluno, ServicoDisciplinaAluno>(new HierarchicalLifetimeManager());
            container.RegisterType<IServicoColegio, ServicoColegio>(new HierarchicalLifetimeManager());

            //Repositorio
            container.RegisterType(typeof(IRepositorioBase<,>), typeof(IRepositorioBase<,>));
            container.RegisterType<IRepositorioAluno, RepositorioAluno>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositorioCurso, RepositorioCurso>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositorioProfessor, RepositorioProfessor>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositorioDisciplina, RepositorioDisciplina>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositorioDisciplinaAluno, RepositorioDisciplinaAluno>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositorioColegio, RepositorioColegio>(new HierarchicalLifetimeManager());

            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Aluno, AlunoResponse>()
                        .ForMember(x => x.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento.ToString("yyyy-MM-dd")));
                    cfg.CreateMap<Professor, ProfessorResponse>()
                        .ForMember(x => x.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento.ToString("yyyy-MM-dd")));
                    cfg.CreateMap<Curso, CursoResponse>();
                    cfg.CreateMap<Disciplina, DisciplinaResponse>();
                    cfg.CreateMap<DisciplinaAluno, DisciplinaAlunoResponse>();
                    cfg.CreateMap<Colegio, ColegioResponse>();
                });
        }
    }
}
