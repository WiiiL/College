import { Component, OnInit } from '@angular/core';
import { ColegioService } from 'src/app/services/colegio.service';
import { Observable } from 'rxjs';
import { UrlConfig } from 'src/app/config/configuracao';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  public colegios : Observable<any>;
  public colegioSelecionado = this.servico.getColegioSelecionado();

  constructor(public servico: ColegioService) {

  }

  ngOnInit() {
    this.colegios = this.servico.listar(UrlConfig.urlApiExemplo + 'colegio/listar');
  }

  mudarColegioSelecionado(value) {
    this.servico.setColegioSelecionado(value);
    location.reload();
  }

}
