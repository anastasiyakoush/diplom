import { Component, OnInit, TemplateRef } from '@angular/core';
import { Teacher } from './teacher.model';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.less']
})
export class TeachersComponent implements OnInit {
  teachers: Teacher[] = [
    {
      id: 1,
      name: 'Лазицкас Е.А.',
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

  ngOnInit() {}

  onClick(id: number) {
    this.router.navigate(['teachers/' + id]);
  }

  addTeacher(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
