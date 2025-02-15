import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserService } from './UserService';

@Injectable()
export class HTTPService implements HttpInterceptor {
  constructor(private userService: UserService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.userService.GetCurrentToken();
    if (token) {
      const authReq = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + token)
      });
      return next.handle(authReq);
    }
    return next.handle(req);
  }
}
