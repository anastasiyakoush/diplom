import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import {FormControl} from '@angular/forms';


@Component({
  selector: 'app-update-curriculum',
  templateUrl: './update-curriculum.component.html',
  styleUrls: ['./update-curriculum.component.less']
})
export class UpdateCurriculumComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();

  bsValue = new Date();
  serializedDate = new FormControl((new Date()).toISOString());
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();

  bsConfig: Partial<BsDatepickerConfig>;

  constructor() {
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
