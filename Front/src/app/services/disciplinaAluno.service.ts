import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';
import { DisciplinaAluno } from '../models/disciplinaAluno.model';

@Injectable({
  providedIn: 'root'
})

export class DisciplinaAlunoService extends BaseService<DisciplinaAluno> {
  
  constructor(httpClient: HttpClient){
    super(httpClient);
  }
}
