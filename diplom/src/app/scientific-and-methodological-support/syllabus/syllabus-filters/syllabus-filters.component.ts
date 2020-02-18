import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-syllabus-filters',
  templateUrl: './syllabus-filters.component.html',
  styleUrls: ['./syllabus-filters.component.less']
})
export class SyllabusFiltersComponent implements OnInit {

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
