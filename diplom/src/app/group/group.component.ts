import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.less']
})
export class GroupComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  modalService: any;
  constructor( private router: Router) { }

  ngOnInit() {
  }

  addGroup(template: TemplateRef<any>) {
    this.title='Добавить группу'
    this.modalRef = this.modalService.show(template);
  }

  updateGroup(template: TemplateRef<any>) {
    this.title='Редактировать группу'
    this.modalRef = this.modalService.show(template);
  }
  navigateToDiscipline(id) {
    this.router.navigate([`/support/1/disciplines`]);
  }
}
