import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  formModel = {
    UserName: '',
    Password: ''
  };

  constructor(private router: Router,) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {

  }
  click() {
    sessionStorage.setItem('token', 'вошел');
    this.router.navigate(['teachers']);

  }
}
