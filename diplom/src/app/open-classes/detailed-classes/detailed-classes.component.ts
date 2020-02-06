import { Component, OnInit } from '@angular/core';
import { Teacher } from 'src/app/teachers/teacher.model';

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

  constructor() { }

  ngOnInit() {
  }

}
