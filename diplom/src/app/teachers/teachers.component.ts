import { Component, OnInit } from '@angular/core';
import { Teacher } from './teacher.model';

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
  constructor() {}

  ngOnInit() {}
}
