import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable} from 'rxjs';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()

export class RequestInterceptor implements HttpInterceptor {
    constructor(private loading: Ng4LoadingSpinnerService, private toastr: ToastrService) {}

    private requests: HttpRequest<any>[] = [];

    removeRequest(req: HttpRequest<any>) {
        const i = this.requests.indexOf(req);
        this.requests.splice(i, 1);
        if (this.requests.length == 0) {
            this.loading.hide();    
        }
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.requests.push(req);
        this.loading.show();
        return Observable.create(observer => {
        const subscription = next.handle(req)
            .subscribe(event => {
                if (event instanceof HttpResponse) {
                    this.removeRequest(req);
                    observer.next(event);
                }
            },
            err => { 
                this.loading.hide();
                if (err instanceof HttpErrorResponse) {
                    if (err.status == 400) {//BadRequest 
                        if (err.error != null) {
                            // inputa msg de erro com o toastr
                            for (let index = 0; index < err.error.errors.length; index++) {
                                this.toastr.info(err.error.errors[index].message);
                            }
                        }
                    }
                    if (err.status == 500) {//InternalServerError
                         // inputa msg de erro com o toastr
                        this.toastr.error('Oops, algo deu errado!')
                    }
                }
                this.removeRequest(req); observer.error(err); 
            },
            () => { this.removeRequest(req); observer.complete(); });
            return () => {
                this.removeRequest(req);
                subscription.unsubscribe();
            };
        });
    }
}