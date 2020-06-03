export class Lesson {
  id: number;
  discipline: string;
  topic: string;
  group: string;
  teacher: string;
  date: string;
}

export class LessonFilter {
  groupsIds?: number[];
  teachersIds?: number[];
  subjectsIds?: number[];
  beginDate?: Date;
  endDate?: Date;
  month?: Month
}

export enum Month {
Январь = 1,
Февраль,
Март,
Апрель,
Май,
Июнь,
Июль,
Август,
Сенятбрь,
Октябрь,
Ноябрь,
Декабрь
}
