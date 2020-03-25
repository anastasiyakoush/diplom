import { Component, OnInit, TemplateRef } from '@angular/core';
import { Lesson } from './lesson.model';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EndpointsService } from '../endpoints.service';

@Component({
  selector: 'app-open-classes',
  templateUrl: './open-classes.component.html',
  styleUrls: ['./open-classes.component.less']
})

export class OpenClassesComponent implements OnInit {
  lessons: Lesson[] = [
    {
      id: 1,
      discipline: 'ПССИП',
      topic: 'CSS',
      group: '62491',
      teacher: 'Терешко',
      date: '26/11/2019'
    },
    {
      id: 2,
      discipline: 'ТРПО',
      topic: 'Методологии проектирования',
      group: '62493',
      teacher: 'Тарасова',
      date: '	15/09/2019'
    },
    {
      id: 3,
      discipline: 'СиАОД',
      topic: 'Структуры данных',
      group: '7к4911',
      teacher: 'Апанасевич',
      date: '26/11/2019'
    }
  ];
  modalRef: BsModalRef;
  searchText: string = "";
  constructor(private router: Router,
    private modalService: BsModalService,
    private endpointService: EndpointsService) {}

  ngOnInit() {}

  onClick(id: number) {
    this.router.navigate(['openClasses/' + id]);
  }

  addClass(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  search() {
     this.endpointService.SearchPublicLesson(this.searchText).subscribe((data:Lesson[])=>this.lessons = data)
  }
}
