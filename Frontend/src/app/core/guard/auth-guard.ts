import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../services/UserService';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private userService: UserService,
    private router: Router
  ) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const requiredRole = route.data['roles'];
    const userRole = this.userService.GetCurrentRole();
    
    if (!this.userService.GetCurrentToken()) {
      this.router.navigate(['/']);
      return false;
    }
    
    if (requiredRole && !requiredRole.includes(userRole)) {
      this.router.navigate(['/unauthorized']);
      return false;
    }
    
    return true;
  }
}