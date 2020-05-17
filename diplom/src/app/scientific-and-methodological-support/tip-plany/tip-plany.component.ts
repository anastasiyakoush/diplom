import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { tipPlan } from './tipPlan.model';
import { setMonth } from 'ngx-bootstrap/chronos/utils/date-setters';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpResponse } from '@angular/common/http/http';

@Component({
  selector: 'app-tip-plany',
  templateUrl: './tip-plany.component.html',
  styleUrls: ['./tip-plany.component.less']
})
export class TipPlanyComponent implements OnInit {
  tipPlans: tipPlan[] = [
  ];

  title: string;
  modalRef: BsModalRef;
  constructor(private router: Router,
     private modalService: BsModalService,
     private endpointService: EndpointsService) {}

  ngOnInit() {
  this.endpointService.getPlans().subscribe(data=> this.tipPlans = data)
  }

  addTipPlan(template: TemplateRef<any>) {
    this.title = 'Добавить типовой план';
    this.modalRef = this.modalService.show(template);
  }

  updateTipPlan(template: TemplateRef<any>) {
    this.title = 'Редактировать типовой план';
    this.modalRef = this.modalService.show(template);
  }

  download(link) {
    this.endpointService.documentDownload(link)
  }

  filterChange($event) {
    console.log($event)
    this.tipPlans = $event;
  }
  delete(id) {
    this.endpointService.DeletePlan(id).subscribe(()=> location.reload())
  }
}
