import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../base/base.component';
import { Professor } from 'src/app/models/professor.model';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ProfessorService } from 'src/app/services/professor.service';

@Component({
  selector: 'app-professor',
  templateUrl: './professor.component.html'
})
export class ProfessorComponent extends BaseComponent<Professor> implements OnInit {

  constructor(
    private fb: FormBuilder,
    public modalService: BsModalService,
    public professorService: ProfessorService) {
    super(modalService, professorService, 'professor', Professor)

  }

  ngOnInit(): void {
    this.form = this.fb.group({
      'nome': ['', Validators.required],
      'salario': ['', Validators.required],
      'dataNascimento': ['', Validators.required]
    });

    this.carregarPagina();
  }
}
