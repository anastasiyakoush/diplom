import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-specialty',
  templateUrl: './specialty.component.html',
  styleUrls: ['./specialty.component.less']
})
export class SpecialtyComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  constructor(private router: Router, private modalService: BsModalService) { }

  ngOnInit() {
  }

  addSpecialty(template: TemplateRef<any>) {
    this.title = 'Добавить специальность';
    this.modalRef = this.modalService.show(template);
  }

  updateSpecialty(template: TemplateRef<any>) {
    this.title = 'Редактировать специальность';
    this.modalRef = this.modalService.show(template);
  }
}
