import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-dolzhnosti',
  templateUrl: './dolzhnosti.component.html',
  styleUrls: ['./dolzhnosti.component.less']
})
export class DolzhnostiComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;

  constructor(private router: Router, private modalService: BsModalService) { }

  ngOnInit() {
  }

  addUser(template: TemplateRef<any>) {
    this.title = 'Добавить пользователя';
    this.modalRef = this.modalService.show(template);
  }

  updateUser(template: TemplateRef<any>) {
    this.title = 'Редактировать пользователя';
    this.modalRef = this.modalService.show(template);
  }

}
