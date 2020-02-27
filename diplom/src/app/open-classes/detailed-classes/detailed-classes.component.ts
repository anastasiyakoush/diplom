import { Component, OnInit, TemplateRef } from '@angular/core';
import { Teacher } from 'src/app/teachers/teacher.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detailed-classes',
  templateUrl: './detailed-classes.component.html',
  styleUrls: ['./detailed-classes.component.less']
})
export class DetailedClassesComponent implements OnInit {

  teachers: Teacher[] = [
    {
      id: 1,
      name: 'Лазицкас Екатерина Александровна',
      category: 'Высшая',
      commision: 'ПОИТ',
      status: 'Работает'
    },
    {
      id: 2,
      name: 'Науменко Жанна Николаевна',
      category: 'Первая',
      commision: '	Общетехнические дисциплины',
      status: 'Работает'
    },
    {
      id: 3,
      name: 'Общетехнические дисциплины',
      category: 'Первая',
      commision: 'ПОИТ',
      status: 'Работает'
    }
  ];

  modalRef: BsModalRef;
  constructor(private router: Router,private modalService: BsModalService) {}

  ngOnInit() {
  }

  updateLesson(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
