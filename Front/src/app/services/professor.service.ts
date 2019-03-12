import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';
import { Professor } from '../models/professor.model';

@Injectable({
  providedIn: 'root'
})

export class ProfessorService extends BaseService<Professor> {
  
  constructor(httpClient: HttpClient){
    super(httpClient);
  }
}
