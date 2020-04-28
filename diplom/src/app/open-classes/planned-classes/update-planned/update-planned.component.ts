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
export class UpdatePlannedComponent
  implements OnInit {
    colorTheme = 'theme-blue';
    bsInlineValue = new Date();
    bsInlineRangeValue: Date[];
    maxDate = new Date();

    bsConfig: Partial<BsDatepickerConfig>;

    constructor(private endpointService: EndpointsService) {
      this.maxDate.setDate(this.maxDate.getDate() + 7);
      this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
      this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
    }
    @Output() cancelClick = new EventEmitter<any>();
    @Output() saveClick = new EventEmitter<any>();
    @Input() title: string;
    teachers: Teacher[] = [];
    teacher: any;
    keys = Object.keys;
    months = Month;
  form = {
    teacher: {},
    status: true,
    month: Month.Декабрь,
  };
    ngOnInit() {
      this.endpointService.getTeachers().subscribe((data: any[]) => {
        this.teachers = data;
        data.forEach((teacher, index) => {
          this.teachers[index].name =
            teacher.surname + " " + teacher.name + " " + teacher.fatherName;
        });
      });
    }

  cancel() {
    this.cancelClick.emit()
  }

  onTeacherChange(teacher) {
    this.form.teacher = teacher;
      }
  save() {
    this.endpointService.createOrUpdatePlannedLesson(this.form).subscribe(()=>    this.saveClick.emit())

  }
}
