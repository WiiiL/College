import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ErroComponent } from './components/erro/erro.component';
import { DisciplinaComponent } from './components/disciplina/disciplina.component';
import { DisciplinaAlunoComponent } from './components/disciplina-aluno/disciplina-aluno.component';
import { AlunoComponent } from './components/aluno/aluno.component';
import { CursoComponent } from './components/curso/curso.component';
import { ProfessorComponent } from './components/professor/professor.component';

const routes: Routes = [
    { path: '',  redirectTo: '/home', pathMatch: 'full' },
    { path: 'erro', component: ErroComponent },
    { path: 'disciplina', component: DisciplinaComponent },
    { path: 'disciplinaAluno', component: DisciplinaAlunoComponent },
    { path: 'aluno', component: AlunoComponent },
    { path: 'curso', component: CursoComponent },
    { path: 'professor', component: ProfessorComponent },
    { path: 'home', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
