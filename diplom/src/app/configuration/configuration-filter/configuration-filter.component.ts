import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-configuration-filter',
  templateUrl: './configuration-filter.component.html',
  styleUrls: ['./configuration-filter.component.less']
})
export class ConfigurationFilterComponent implements OnInit {

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

  ngOnInit() {
  }

}
