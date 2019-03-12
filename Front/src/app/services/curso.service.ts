import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';
import { Curso } from '../models/curso.model';
import { Observable } from 'rxjs';
import { UrlConfig } from '../config/configuracao';

@Injectable({
  providedIn: 'root'
})

export class CursoService extends BaseService<Curso> {
    dashboard(): Observable<any> {
        return this.get<any>(UrlConfig.urlApiExemplo + 'curso/dashboard?colegioId=' + localStorage.getItem('colegioSelecionado'));
    }
  
  constructor(httpClient: HttpClient){
    super(httpClient);
  }
}
