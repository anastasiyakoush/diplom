import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { Plan } from './plan.model';
import { setMonth } from 'ngx-bootstrap/chronos/utils/date-setters';
import { EndpointsService } from 'src/app/endpoints.service';

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
      link: 'ссылка',
    },
    {
      id: 2,
      name: 2,
      nomer: 2,
      date: '15/09/2019',
      link: 'ссылка',
    },
    {
      id: 3,
      name: 3,
      nomer: 191,
      date: '26/11/2019',
      link: 'ссылка',
    }
  ];

  title: string;
  modalRef: BsModalRef;
  constructor(private router: Router,
     private modalService: BsModalService,
     private endpointService: EndpointsService) {}

  ngOnInit() {
  //  this.endpointService.getPlans().subscribe(data=> this.plans = data)
  }

  addUchPlan(template: TemplateRef<any>) {
    this.title = 'Добавить учебный план';
    this.modalRef = this.modalService.show(template);
  }

  updateUchPlan(template: TemplateRef<any>) {
    this.title = 'Редактировать учебный план';
    this.modalRef = this.modalService.show(template);
  }
}
