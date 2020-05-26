import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EndpointsService } from '../endpoints.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

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

  constructor(private router: Router,
    private toastr: ToastrService,
    private endpointService: EndpointsService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {

    this.endpointService.signIn(form.value).subscribe(
      (res: any) => {
        sessionStorage.setItem('token', res.token);
        this.router.navigate(['teachers']);
      },
      err => {
        if (err instanceof HttpErrorResponse) {
          if (err.status == 400) {
            this.toastr.error(
              'Incorrect username or password.',
              'Authentication failed.'
            );
          } else {
            console.log(err);
          }
        }
      }
    );
  }
}
