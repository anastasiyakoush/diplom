import { Component, OnInit } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

@Component({
  selector: 'app-curriculum-filters',
  templateUrl: './curriculum-filters.component.html',
  styleUrls: ['./curriculum-filters.component.less']
})
export class CurriculumFiltersComponent implements OnInit {
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

  dropdownSettings: IDropdownSettings;
  dropdownList = [];
  selectedItems = [];
  ngOnInit() {
    this.dropdownList = [
      { item_id: 1, item_text: '62491' },
      { item_id: 2, item_text: '62492' },
      { item_id: 3, item_text: '62493' },
      { item_id: 4, item_text: '7к2411' },
    ];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Выбрать все',
      unSelectAllText: 'Отменить все',
      itemsShowLimit: 3,
      allowSearchFilter: true
    }; 
  }
  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
}
