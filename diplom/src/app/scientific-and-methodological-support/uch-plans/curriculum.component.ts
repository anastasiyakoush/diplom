import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { Plan } from './plan.model';
import { setMonth } from 'ngx-bootstrap/chronos/utils/date-setters';

@Component({
  selector: 'app-curriculum',
  templateUrl: './curriculum.component.html',
  styleUrls: ['./curriculum.component.less']
})
export class CurriculumComponent implements OnInit {
  plans: Plan[] = [
    {
      id: 1,
      name: 1,
      nomer: 131,
      date: '26/11/2019',
      developer: 'Фамилия'
    },
    {
      id: 2,
      name: name,
      nomer: 2,
      date: '15/09/2019',
      developer: 'Фамилия'
    },
    {
      id: 3,
      name: 3,
      nomer: 191,
      date: '26/11/2019',
      developer: 'Фамилия'
    }
  ];
  modalRef: BsModalRef;
  constructor(private router: Router, private modalService: BsModalService) {}

  ngOnInit() {
  }

  addPlan(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
