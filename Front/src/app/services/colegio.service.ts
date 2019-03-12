import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';
import { Colegio } from '../models/colegio.model';

@Injectable({
    providedIn: 'root'
})

export class ColegioService extends BaseService<Colegio> {
    constructor(httpClient: HttpClient) {
        super(httpClient);
    }

    getColegioSelecionado() {
        let colegio = localStorage.getItem('colegioSelecionado');
        if(colegio == null || colegio == undefined){
            this.setColegioSelecionado(1);
            return 1;
        } else {
            parseInt(colegio);
        }
    }

    setColegioSelecionado(valor) {
        localStorage.setItem('colegioSelecionado', valor);
    }
}
