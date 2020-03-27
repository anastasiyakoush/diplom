import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { setMonth } from 'ngx-bootstrap/chronos/utils/date-setters';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-detailed-syllabus',
  templateUrl: './detailed-syllabus.component.html',
  styleUrls: ['./detailed-syllabus.component.less']
})
export class DetailedSyllabusComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  constructor(private router: Router,
     private modalService: BsModalService) {}

  ngOnInit() {
  }

  addDocument(template: TemplateRef<any>) {
    this.title = 'Добавить документ';
    this.modalRef = this.modalService.show(template);
  }

  updateDocument(template: TemplateRef<any>) {
    this.title = 'Редактировать документ';
    this.modalRef = this.modalService.show(template);
  }

  onClick(id: number) {
    this.router.navigate(['detailedSyllabus/' + id]);
  }
}
