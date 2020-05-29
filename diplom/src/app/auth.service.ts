import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import * as jwtDecode from 'jwt-decode';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient, private router: Router) { }
  jwtHelper = new JwtHelperService();

  logout() {
    sessionStorage.removeItem('token');
    this.router.navigateByUrl('/authorization/login');
  }

  isAuthenticated() {
    const token = sessionStorage.getItem('token');
    return this.jwtHelper.isTokenExpired(token);
  }

  isAdmin() {
    const token = sessionStorage.getItem('token');
    if (token) {
      const tokenPayload = jwtDecode(token);
      return !this.isAuthenticated() && tokenPayload['role'] === 'Admin'
    } else return false;
  }

  isUser() {
    const token = sessionStorage.getItem('token');
    if (token) {
      const tokenPayload = jwtDecode(token);
      return !this.isAuthenticated() && tokenPayload['role'] === 'User'
    } else return false;
  }
}
