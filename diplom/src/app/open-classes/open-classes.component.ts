import { Component, OnInit, TemplateRef } from '@angular/core';
import { Lesson } from './lesson.model';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-open-classes',
  templateUrl: './open-classes.component.html',
  styleUrls: ['./open-classes.component.less']
})
export class OpenClassesComponent implements OnInit {
  lessons: Lesson[] = [
    {
      id: 1,
      topic: 'CSS',
      group: '62491',
      teacher: 'Терешко',
      plan: 'ссылка',
      date: '26/11/2019/'
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
      date: '26/11/2019/'
    }
  ];
  modalRef: BsModalRef;
  constructor(private router: Router,private modalService: BsModalService) {}

  ngOnInit() {}

  onClick(id: number) {
    this.router.navigate(['openClasses/' + id]);
  }

  addLesson(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
