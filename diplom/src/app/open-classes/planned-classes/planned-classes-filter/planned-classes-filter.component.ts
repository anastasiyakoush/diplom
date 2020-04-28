import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { IDropdownSettings } from "ng-multiselect-dropdown";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import { EndpointsService } from "src/app/endpoints.service";
import { LessonFilter, Month } from '../../lesson.model';

@Component({
  selector: "app-planned-classes-filter",
  templateUrl: "./planned-classes-filter.component.html",
  styleUrls: ["./planned-classes-filter.component.less"],
})
export class PlannedClassesFilterComponent implements OnInit {
  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  dropdownSettings: IDropdownSettings;
  dropdownList2 = [];
  selectedItems2 = [];

  keys = Object.keys;
  months = Month;
  form : LessonFilter =  {
    teachersIds: [],
    month: Month.Декабрь,
  };
  bsConfig: Partial<BsDatepickerConfig>;
  bsConfig1: Partial<BsDatepickerConfig>;
  lessons: any[];
  @Output() onChangedFilter = new EventEmitter<any[]>();

  constructor(private endpointService: EndpointsService) {
  }

  ngOnInit() {
    this.endpointService.getTeachers().subscribe((data) => {
      this.dropdownList2 = data.map((item) => {
        return {
          name: item.surname + " " + item.name + " " + item.fatherName,
          id: item.id,
        };
      });
    });
    this.dropdownSettings = {
      singleSelection: false,
      idField: "id",
      textField: "name",
      selectAllText: "Выбрать все",
      unSelectAllText: "Отменить все",
      itemsShowLimit: 3,
      allowSearchFilter: true,
    };
  }

  onItem1Select(item: any) {
    this.form.groupIds.push(item.id);
  }

  onItem2Select(item: any) {
    this.form.teachersIds.push(item.id);
  }

  onItem3Select(item: any) {
    this.form.subjectsIds.push(item.id);
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
