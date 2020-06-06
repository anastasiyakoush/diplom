import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { Plan } from './plan.model';
import { setMonth } from 'ngx-bootstrap/chronos/utils/date-setters';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpResponse } from '@angular/common/http/http';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-curriculum',
  templateUrl: './curriculum.component.html',
  styleUrls: ['./curriculum.component.less']
})
export class CurriculumComponent implements OnInit {
  uchPlans: Plan[] = [];
  uchPlanId: number;
  title: string;
  update: boolean;
  modalRef: BsModalRef;
  constructor(private router: Router,
              private modalService: BsModalService,
              private auth: AuthService,
              private endpointService: EndpointsService) {}

  ngOnInit() {
    this.endpointService.getPlans().subscribe(data => this.uchPlans = data);
  }

  addUchPlan(template: TemplateRef<any>) {
    this.title = 'Добавить учебный план';
    this.update = false;
    this.modalRef = this.modalService.show(template);
  }

  updateUchPlan(template: TemplateRef<any>, id) {
    this.uchPlanId = id;
    this.title = 'Редактировать учебный план';
    this.update = true;
    this.modalRef = this.modalService.show(template);
  }

  download(link) {
    this.endpointService.documentDownload(link);
  }

  filterChange($event) {
    console.log($event)
    this.uchPlans = $event;
  }
  delete(id) {
    this.endpointService.DeletePlan(id).subscribe(() => location.reload())
  }
}
