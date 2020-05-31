import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { Standart } from './standart.model';
import { setMonth } from 'ngx-bootstrap/chronos/utils/date-setters';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpResponse } from '@angular/common/http/http';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-obrazov-standart',
  templateUrl: './obrazov-standart.component.html',
  styleUrls: ['./obrazov-standart.component.less']
})
export class ObrazovStandartComponent implements OnInit {
  standarts: Standart[] = [
  ];
  update: boolean;
  title: string;
  modalRef: BsModalRef;
  obrStId: number;
  constructor(private router: Router,
     private modalService: BsModalService,
     private auth: AuthService,
     private endpointService: EndpointsService) {}

  ngOnInit() {
  this.endpointService.getObrPlans().subscribe(data=> this.standarts = data)
  }

  addUchPlan(template: TemplateRef<any>) {
    this.update = false;
    this.title = 'Добавить образовательный стандарт';
    this.modalRef = this.modalService.show(template);
  }

  updateUchPlan(template: TemplateRef<any>,id) {
    this.update = true;
    this.obrStId = id;
    this.title = 'Редактировать образовательный стандарт';
    this.modalRef = this.modalService.show(template);
  }

  download(link) {
    this.endpointService.documentDownload(link)
  }

  filterChange($event) {
    console.log($event)
    this.standarts = $event;
  }
  delete(id) {
    this.endpointService.DeletePlan(id).subscribe(()=> location.reload())
  }
}
