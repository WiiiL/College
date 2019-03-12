import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Disciplina } from 'src/app/models/disciplina.model';
import { FormBuilder, Validators } from '@angular/forms';
import { DisciplinaService } from 'src/app/services/disciplina.service';
import { BaseComponent } from '../base/base.component';
import { Observable } from 'rxjs';
import { CursoService } from 'src/app/services/curso.service';
import { ProfessorService } from 'src/app/services/professor.service';
import { UrlConfig } from 'src/app/config/configuracao';

@Component({
  selector: 'app-disciplina',
  templateUrl: './disciplina.component.html'
})
export class DisciplinaComponent extends BaseComponent<Disciplina> implements OnInit {

  constructor( private fb: FormBuilder,
    public modalService: BsModalService,
    public cursoService: CursoService,
    public professorService: ProfessorService,
    public service: DisciplinaService) {
    super(modalService, service, 'disciplina', Disciplina)
  }

  public cursos: Observable<any>;
  public professores: Observable<any>;

  ngOnInit(): void {
    this.form = this.fb.group({
      'nome': ['', Validators.required],
      'cursoId': ['', Validators.required],
      'professorId': ['', Validators.required],
    });

    this.cursos = this.cursoService.listar(UrlConfig.urlApiExemplo + 'curso/listar?colegioId=' + localStorage.getItem('colegioSelecionado'));
    this.professores = this.professorService.listar(UrlConfig.urlApiExemplo + 'professor/listar');
    this.carregarPagina();
  }

  carregarPagina() {
    this.listagem = this.service.listar(UrlConfig.urlApiExemplo + 'disciplina/listar?colegioId=' + localStorage.getItem('colegioSelecionado'));
  }
}