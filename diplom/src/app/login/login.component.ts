import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

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

  constructor() { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {

  }

}
