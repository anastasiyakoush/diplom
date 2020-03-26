import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-update-syllabus',
  templateUrl: './update-syllabus.component.html',
  styleUrls: ['./update-syllabus.component.less']
})
export class UpdateSyllabusComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();

  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  form ={
    registarcionnyjNomer: '',
    date: new Date(),
    name: "",
    laboratornye:0,
    practika:0,
    kursovoeProectirovanie:0,
    link: '',
    dependencyId: 2

  }
  bsConfig: Partial<BsDatepickerConfig>;

  constructor( private endpointService: EndpointsService) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
   }

  ngOnInit() {}

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.saveClick.emit()
  }
}
