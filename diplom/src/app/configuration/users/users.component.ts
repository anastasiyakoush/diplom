import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { EndpointsService } from 'src/app/endpoints.service';
import { Role } from 'src/app/enums';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.less']
})
export class UsersComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  users: any[];
  userId: number;
  searchText ="";
  constructor(private router: Router, private modalService: BsModalService,
    private endpointService: EndpointsService) {}

  ngOnInit() {
    this.endpointService.getAllUsers().subscribe((data) => {
      this.users = data;
      this.users.map((user,index)=>{
        if(user.role == 0) {
          user.role = 'admin'
        } else {
          user.role = 'user'
        }})
    });
  }

  addUser(template: TemplateRef<any>) {
    this.title = 'Добавить пользователя';
    this.modalRef = this.modalService.show(template);
  }

  updateUser(template: TemplateRef<any> , id) {
this.userId = id;
    this.title = 'Редактировать пользователя';
    this.modalRef = this.modalService.show(template);
  }

  delete(id) {
    this.endpointService.deleteUser(id).subscribe(()=> location.reload())
  }

  cancel() {
    this.modalRef.hide();
    this.userId = undefined;
  }

  search() {
    this.endpointService.searchUser(this.searchText).subscribe((data: any) => {
      this.users = data;
      this.users.map((user,index)=>{
        if(user.role == 0) {
          user.role = 'admin'
        } else {
          user.role = 'user'
        }})
      })
  }

}
