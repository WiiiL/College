import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';
import { Disciplina } from '../models/disciplina.model';
import { Observable } from 'rxjs';
import { UrlConfig } from '../config/configuracao';

@Injectable({
  providedIn: 'root'
})

export class DisciplinaService extends BaseService<Disciplina> {
    relatorio(): Observable<any> {
        return this.get<any>(UrlConfig.urlApiExemplo + 'disciplina/listarDisciplinas?colegioId=' + localStorage.getItem('colegioSelecionado'));
    }
  
  constructor(httpClient: HttpClient){
    super(httpClient);
  }
}
