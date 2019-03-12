import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';
import { Aluno } from '../models/aluno.model';
import { Observable } from 'rxjs';
import { UrlConfig } from '../config/configuracao';

@Injectable({
  providedIn: 'root'
})

export class AlunoService extends BaseService<Aluno> {

  listar(): Observable<any> {
    return this.get<any>(UrlConfig.urlApiExemplo + 'aluno/listar');
  }

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }
}
