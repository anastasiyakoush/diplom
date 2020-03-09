import { Component, OnInit, TemplateRef, OnDestroy } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { Group } from './group.model';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.less']
})
export class GroupComponent implements OnInit, OnDestroy{
  title: string;
  modalRef: BsModalRef;
  groups: Group[] = [
    {
      id: 1,
      nomer: '62491',
      CK: 'ПОИТ'
    },
    {
      id: 2,
      nomer: '7к2411',
      CK: 'ПОИТ'
    }
  ];

  constructor( private router: Router,
    private modalService: BsModalService) { }

  ngOnInit() {
  }
  ngOnDestroy() {}
  addGroup(template: TemplateRef<any>) {
    this.title='Добавить группу'
    this.modalRef = this.modalService.show(template);
  }

  updateGroup(template: TemplateRef<any>) {
    this.title='Редактировать группу'
    this.modalRef = this.modalService.show(template);
  }

  navigateToDiscipline(id) {
    this.router.navigate(['support/' + id + '/plan']);
  }
}
