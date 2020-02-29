import { Component, OnInit, TemplateRef } from '@angular/core';
import { Lesson } from 'src/app/open-classes/lesson.model';
import { Teacher } from '../teacher.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detailed-teachers',
  templateUrl: './detailed-teachers.component.html',
  styleUrls: ['./detailed-teachers.component.less']
})
export class DetailedTeachersComponent implements OnInit {

  actlesson:boolean = true;
  actsupport:boolean = false;

  lessons: Lesson[] = [
    {
      id: 1,
      topic: 'CSS',
      group: '62491',
      teacher: 'Терешко',
      plan: 'ссылка',
      date: '26/11/2019'
    },
    {
      id: 1,
      topic: 'Методологии проектирования',
      group: '62493',
      teacher: 'Тарасова',
      plan: 'ссылка',
      date: '	15/09/2019'
    },
    {
      id: 1,
      topic: 'Структуры данных',
      group: '7к4911',
      teacher: 'Апанасевич',
      plan: 'ссылка',
      date: '26/11/2019'
    }
  ];

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
  constructor(private router: Router, private modalService: BsModalService) {}

  ngOnInit() {
  }

  change(num:number) {
    if (num === 1) {
      this.actlesson = true;
      this.actsupport = false;
    }
    else {
      this.actlesson = false;
      this.actsupport = true;
    }
  }

  UpdateTeacher(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
