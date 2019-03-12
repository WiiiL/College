import { Component, TemplateRef, ViewChild } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { SwalComponent } from '@toverux/ngx-sweetalert2';
import { BaseService } from 'src/app/services/base/base.service';
import { FormGroup } from '@angular/forms';
import { ResponseBase } from 'src/app/models/base/responseBase.model';
import { Observable } from 'rxjs';
import { UrlConfig } from 'src/app/config/configuracao';

@Component({
  selector: 'app-base',
})

export class BaseComponent<T> {
  modalRef: BsModalRef;
  titulo: string;
  config = { ignoreBackdropClick: true, keyboard: false, class: "" };
  @ViewChild('sucessoSwal') public sucessoSwal: SwalComponent;
  private TCreator: new () => T;

  public obj: T;
  public form: FormGroup;
  public editar: boolean;
  public listagem: Observable<any>;
  
  constructor(public modalService: BsModalService, public service: BaseService<T>, 
    public url: string, TCreator: { new(): T; }) { 
    this.TCreator = TCreator;
    this.obj = this.criarObjeto();
  }

  carregarPagina() {
    this.listagem = this.service.listar(UrlConfig.urlApiExemplo + this.url + '/listar');
  }

  criarObjeto() {
    return new this.TCreator();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, this.config);
  }

  closeModal() {
    if (this.modalRef != undefined)
      this.modalRef.hide();
  }

  adicionar(template: TemplateRef<any>, titulo: string) {
    if (this.form != undefined) this.form.reset();
    this.obj = this.criarObjeto();
    this.titulo = titulo;
    this.editar = false;
    this.openModal(template);
  }

  atualizar(item: T, template: TemplateRef<any>, titulo: string) {
    if (this.form != undefined) this.form.reset();
    this.obj = Object.assign({}, item);
    this.titulo = titulo;
    this.editar = true;
    this.openModal(template);
  }

  confirmar() {
    // Valida o formulario
    if (this.form != undefined && this.form.invalid) {
      for (let i in this.form.controls) { this.form.controls[i].markAsTouched(); }
      return;
    }

    if (!this.editar) {
      this.service.post<ResponseBase>(UrlConfig.urlApiExemplo + this.url + "/adicionar", this.obj)
        .subscribe(
          (res: ResponseBase) => {
            this.closeModal();
            this.sucessoSwal.show();
          }
        );
    } else {
      this.service.put<ResponseBase>(UrlConfig.urlApiExemplo + this.url + "/atualizar", this.obj)
        .subscribe(
          (res: ResponseBase) => {
            this.closeModal();
            this.sucessoSwal.show();
          }
        );
    }
  }
}
