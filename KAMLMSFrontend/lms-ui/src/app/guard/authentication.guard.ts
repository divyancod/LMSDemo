import { Injectable } from '@angular/core';
import { CanLoad, Route, Router, UrlSegment, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../service/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanLoad {
  /**
   *
   */
  constructor(private loginService: AuthService, private router: Router) {
  }
  canLoad(route: Route, segments: UrlSegment[]): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this.loginService.isUserAuthenticated()) {
      return true;
    } else {
      this.router.navigate(["/login"])
      return false;
    }
  }

}
