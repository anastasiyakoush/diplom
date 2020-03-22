import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.less']
})
export class GroupsComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  constructor(private router: Router, private modalService: BsModalService) { }

  ngOnInit() {
  }

  addGroup(template: TemplateRef<any>) {
    this.title = 'Добавить группу';
    this.modalRef = this.modalService.show(template);
  }

  updateGroup(template: TemplateRef<any>) {
    this.title = 'Редактировать группу';
    this.modalRef = this.modalService.show(template);
  }
}
