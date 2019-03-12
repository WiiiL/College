import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, Validators } from '@angular/forms';
import { DisciplinaService } from 'src/app/services/disciplina.service';
import { BaseComponent } from '../base/base.component';
import { Observable } from 'rxjs';
import { CursoService } from 'src/app/services/curso.service';
import { UrlConfig } from 'src/app/config/configuracao';
import { DisciplinaAluno } from 'src/app/models/disciplinaAluno.model';
import { DisciplinaAlunoService } from 'src/app/services/disciplinaAluno.service';

@Component({
  selector: 'app-disciplina-aluno',
  templateUrl: './disciplina-aluno.component.html'
})
export class DisciplinaAlunoComponent extends BaseComponent<DisciplinaAluno> implements OnInit {

  constructor( private fb: FormBuilder,
    public modalService: BsModalService,
    public alunoService: CursoService,
    public disciplinaService: DisciplinaService,
    public service: DisciplinaAlunoService) {
    super(modalService, service, 'disciplinaAluno', DisciplinaAluno)
  }

  public alunos: Observable<any>;
  public disciplinas: Observable<any>;

  ngOnInit(): void {
    this.form = this.fb.group({
      'nota': ['', Validators.required],
      'alunoId': ['', Validators.required],
      'disciplinaId': ['', Validators.required],
    });

    this.alunos = this.alunoService.listar(UrlConfig.urlApiExemplo + 'aluno/listar');
    this.disciplinas = this.disciplinaService.listar(UrlConfig.urlApiExemplo + 'disciplina/listar?colegioId=' + localStorage.getItem('colegioSelecionado'));
    this.carregarPagina();
  }
}