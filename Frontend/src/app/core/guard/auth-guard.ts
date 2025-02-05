import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../services/UserService';
import { SnackBar } from 'src/app/shared/components/snack-bar/snack-bar.component';

@Injectable({
    providedIn: 'root'
})

export class AuthGuard implements CanActivate {

    constructor(private userService: UserService, private router: Router, private snackBar: SnackBar) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        const allowedRoles = next.data['roles'] as Array<string>;
        const userRoles = this.userService.getCurrentAccessLevel();

        const hasAccess = allowedRoles.some(role => userRoles?.toLowerCase().includes(role.toLowerCase()));
        if (!hasAccess) {
            this.snackBar.open("Unauthorized", true);
            this.router.navigate(['']);
        }

        return hasAccess;
    }
}
