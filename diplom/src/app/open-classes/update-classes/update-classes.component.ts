import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: "app-update-classes",
  templateUrl: "./update-classes.component.html",
  styleUrls: ["./update-classes.component.less"]
})
export class UpdateClassesComponent
implements OnInit {
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
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;

  ngOnInit() {}

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.saveClick.emit()
  }
}
