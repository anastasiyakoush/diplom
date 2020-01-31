import { Component, OnInit } from '@angular/core';
import { Lesson } from './lesson.model';

@Component({
  selector: "app-open-classes",
  templateUrl: "./open-classes.component.html",
  styleUrls: ["./open-classes.component.less"]
})
export class OpenClassesComponent implements OnInit {
  lessons: Lesson[] = [
    {
      id: 1,
      topic: "	CSS",
      group: "62491",
      teacher: "Терешко",
      plan: "ссылка",
      date: "26/11/2019/"
    },
    {
      id: 1,
      topic: "	Методологии проектирования",
      group: "62493",
      teacher: "Тарасова",
      plan: "ссылка",
      date: "	15/09/2019"
    },
    {
      id: 1,
      topic: "	Структуры данных",
      group: "7к4911",
      teacher: "Апанасевич",
      plan: "ссылка",
      date: "26/11/2019/"
    }
  ];

  constructor() {}

  ngOnInit() {}
}
