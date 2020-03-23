import { Component, OnInit, EventEmitter, Input, Output, OnDestroy } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import {FormControl} from '@angular/forms';


@Component({
  selector: 'app-update-curriculum',
  templateUrl: './update-curriculum.component.html',
  styleUrls: ['./update-curriculum.component.less']
})
export class UpdateCurriculumComponent implements OnInit, OnDestroy {
  addBtn = false;

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;

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
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    this.saveClick.emit();
  }

  addFile() {
    this.addBtn = true;
  }

}
