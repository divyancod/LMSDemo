import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, of, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthCallInterceptor implements HttpInterceptor {

  constructor(private router:Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var token = localStorage.getItem("lms_ui_token")
        const newReq = req.clone({ headers: req.headers.append('Authorization', `Bearer ${token}`) });
        return next.handle(newReq).pipe(catchError(x=>this.handleAuthError(x)))
    }

    private handleAuthError(err: HttpErrorResponse): Observable<any> {
        if (err.status === 401 || err.status === 403) {
            localStorage.removeItem("lms_ui_token")
            this.router.navigate(['login'],{queryParams:{error:'true'}})
            return of(err.message);
        }
        return throwError(()=> new Error(err.error));
    }
}
