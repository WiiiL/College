import { Component, OnInit } from '@angular/core';
import { AlunoService } from 'src/app/services/aluno.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BaseComponent } from '../base/base.component';
import { Aluno } from 'src/app/models/aluno.model';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html'
})
export class AlunoComponent extends BaseComponent<Aluno> implements OnInit {

  constructor(
    private fb: FormBuilder,
    public modalService: BsModalService, 
    public alunoService: AlunoService) {
    super(modalService, alunoService, 'aluno', Aluno);
  }

  ngOnInit() {
    this.form = this.fb.group({
      'nome': ['', Validators.required],
      'matricula': ['', Validators.required],
      'dataNascimento': ['', Validators.required]
    });

    this.carregarPagina();
  }
}
