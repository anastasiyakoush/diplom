import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import * as jwt_decode from 'jwt-decode';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
    helper = new JwtHelperService();
    constructor(private auth: AuthService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        const expectedRole = route.data.expectedRole;
        const token = sessionStorage.getItem('token');
        const tokenPayload = this.getDecodedAccessToken(token);

        if (!this.auth.isAuthenticated() && tokenPayload.role === expectedRole) {
            return true;
        }
        else {
            this.router.navigate(['authorization/login']);
            return false;
        }
    }

    getDecodedAccessToken(token: string): any {
        try {
            return jwt_decode(token);
        }
        catch (Error) {
            return null;
        }
    }
}
