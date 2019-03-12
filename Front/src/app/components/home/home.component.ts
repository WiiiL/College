import { Component, OnInit } from '@angular/core';
import { CursoService } from 'src/app/services/curso.service';
import { Observable } from 'rxjs';
import { DisciplinaService } from 'src/app/services/disciplina.service';

@Component({
    selector: 'app-home',
    templateUrl: '../home/home.component.html',
})

export class HomeComponent implements OnInit {

    public dashboard: Observable<any>;
    public disciplinas: Observable<any>;

    constructor(public cursoService: CursoService, public disciplinaService: DisciplinaService) {
    }

    ngOnInit(): void {
        this.dashboard = this.cursoService.dashboard();
        this.disciplinas = this.disciplinaService.relatorio();
    }
}
