import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-update-configuration',
  templateUrl: './update-configuration.component.html',
  styleUrls: ['./update-configuration.component.less']
})
export class UpdateConfigurationComponent implements OnInit {
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();

  //bsConfig: Partial<BsDatepickerConfig>;

  constructor() {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    //this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
   }

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  ngOnInit() {}

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.saveClick.emit()
  }

}
