import { Component, OnInit, TemplateRef  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less']
})
export class HeaderComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  token: string;
  constructor(private route: ActivatedRoute, private router: Router,
     private modalService: BsModalService,
     private auth: AuthService) { }

  ngOnInit() {
    this.token = sessionStorage.getItem('token');
  }
  ngOnChanges() {

  }

  addDocument(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  logout() {
    sessionStorage.removeItem('token');
    location.reload()
  }

  login() {
    this.router.navigate(['authorization/login']);
  }
}
