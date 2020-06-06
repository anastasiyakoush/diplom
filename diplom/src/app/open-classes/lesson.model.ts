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
  month?: Month;
}

export enum Month {
  'Не выбрано' = 13,
  'Январь' = 1,
  'Февраль' = 2,
  'Март'= 3,
  'Апрель' = 4,
  'Май' = 5,
  'Июнь' = 6,
  'Июль' = 7,
  'Август' = 8,
  'Сенятбрь' = 9,
  'Октябрь' = 10,
  'Ноябрь' = 11,
  'Декабрь' = 12,
  }
