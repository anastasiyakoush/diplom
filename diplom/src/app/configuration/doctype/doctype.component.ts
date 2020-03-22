import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-doctype',
  templateUrl: './doctype.component.html',
  styleUrls: ['./doctype.component.less']
})
export class DoctypeComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  constructor(private router: Router, private modalService: BsModalService) { }

  ngOnInit() {
  }

  addType(template: TemplateRef<any>) {
    this.title = 'Добавить тип документа';
    this.modalRef = this.modalService.show(template);
  }

  updateType(template: TemplateRef<any>) {
    this.title = 'Редактировать тип документа';
    this.modalRef = this.modalService.show(template);
  }
}
