import { HttpClient } from '@angular/common/http';

export class BaseService<T> implements IBaseService {
    private _http: HttpClient;

    constructor(_http: HttpClient) {
        this._http = _http;
    }

    listar(url: string): any {
        return this.get<any>(url);
    }

    get<T>(url) {
        return this._http.get<T[]>(url)
    }

    post<T>(url, parametro) {
        return this._http.post<T>(url, parametro);
    }

    put<T>(url, parametro) {
        return this._http.put<T>(url, parametro);
    }
}