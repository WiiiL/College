import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../base/base.component';
import { Curso } from 'src/app/models/curso.model';
import { ProfessorService } from 'src/app/services/professor.service';
import { FormBuilder, Validators } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { CursoService } from 'src/app/services/curso.service';
import { UrlConfig } from 'src/app/config/configuracao';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html'
})

export class CursoComponent extends BaseComponent<Curso> implements OnInit {

  constructor( private fb: FormBuilder,
    public modalService: BsModalService,
    public service: CursoService) {
    super(modalService, service, 'curso', Curso)
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      'nome': ['', Validators.required]
    });

    this.carregarPagina();
  }
  
  carregarPagina() {
    this.listagem = this.service.listar(UrlConfig.urlApiExemplo + 'curso/listar?colegioId=' + localStorage.getItem('colegioSelecionado'));
  }

  confirmarForm() {
    this.obj.colegioId = parseInt(localStorage.getItem('colegioSelecionado'));
    this.confirmar();
  }
}
