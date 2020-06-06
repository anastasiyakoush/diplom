import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { EndpointsService } from 'src/app/endpoints.service';
import { Teacher } from 'src/app/teachers/teacher.model';
import { Month } from '../../lesson.model';

@Component({
  selector: 'app-update-planned',
  templateUrl: './update-planned.component.html',
  styleUrls: ['./update-planned.component.less']
})
export class UpdatePlannedComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() lessonId: number;
  @Input() update: boolean;

    colorTheme = 'theme-blue';
    bsInlineValue = new Date();
    bsInlineRangeValue: Date[];
    maxDate = new Date();
    bsConfig: Partial<BsDatepickerConfig>;
    teachers = [];
    teacher: any;
    keys = Object.keys;
    form = {
      teacher: {},
      status: true,
      month: Month.Декабрь,
    };
    Month: typeof Month = Month;
    month = Month;
    months: any = null;

  constructor(private endpointService: EndpointsService) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }
    ngOnInit() {
      if(this.update) {
        this.endpointService.getPlannedLessonById(this.lessonId).subscribe((data: any[]) => {
          this.form = <any>data;
        });
      }

      this.endpointService.getTeachers().subscribe(data=> {
        this.teachers = data;
        data.forEach((teacher, index)=> {
          this.teachers[index].name = teacher.surname +" "+ teacher.name  +" "+  teacher.fatherName;
          })
      })
      var months = Object.keys(Month);
      this.months = months.slice(months.length / 2);
    }

  cancel() {
    this.cancelClick.emit()
  }

  onTeacherChange(teacherId) {
    debugger
    this.form.teacher = this.teachers.find(t=> t.id === Number(teacherId));
  }

  onMonthChange(month: string) {
    this.form.month = Month[month];
  }

  save() {
    this.endpointService.createOrUpdatePlannedLesson(this.form).subscribe(()=>    this.saveClick.emit())

  }
}
