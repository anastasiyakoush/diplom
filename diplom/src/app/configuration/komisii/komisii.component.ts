import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-komisii',
  templateUrl: './komisii.component.html',
  styleUrls: ['./komisii.component.less']
})
export class KomisiiComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  constructor(private router: Router, private modalService: BsModalService) { }

  ngOnInit() {
  }

  addKomisii(template: TemplateRef<any>) {
    this.title = 'Добавить цикловую комиссию';
    this.modalRef = this.modalService.show(template);
  }

  updateKomisii(template: TemplateRef<any>) {
    this.title = 'Редактировать цикловую комиссию';
    this.modalRef = this.modalService.show(template);
  }

}
