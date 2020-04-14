import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { IDropdownSettings } from "ng-multiselect-dropdown";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import { EndpointsService } from "src/app/endpoints.service";

@Component({
  selector: "app-classes-filter",
  templateUrl: "./classes-filter.component.html",
  styleUrls: ["./classes-filter.component.less"]
})
export class ClassesFilterComponent implements OnInit {
  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  form = {
    groupIds: [7]
  };
  bsConfig: Partial<BsDatepickerConfig>;
  lessons: any[];
  @Output() onChangedFilter = new EventEmitter<any[]>();

  constructor(private endpointService: EndpointsService) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }

  dropdownSettings: IDropdownSettings;
  dropdownList1 = [];
  dropdownList2 = [];
  selectedItems1 = [];
  selectedItems2 = [];
  ngOnInit() {
    this.dropdownList1 = [
      { item_id: 1, item_text: "62491" },
      { item_id: 2, item_text: "62492" },
      { item_id: 3, item_text: "62493" },
      { item_id: 4, item_text: "7к2411" }
    ];
    this.dropdownList2 = [
      { item_id: 1, item_text: "Лазицкас" },
      { item_id: 2, item_text: "Карпович" },
      { item_id: 3, item_text: "Ашуркевич" },
      { item_id: 4, item_text: "Виничук" }
    ];
    this.dropdownSettings = {
      singleSelection: false,
      idField: "item_id",
      textField: "item_text",
      selectAllText: "Выбрать все",
      unSelectAllText: "Отменить все",
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }
  filter() {
    this.endpointService
      .FilterPublicLesson(this.form)
      .subscribe((data: any[]) => {
        this.lessons = data;
        this.onChangedFilter.emit(this.lessons);
      });
  }
}
