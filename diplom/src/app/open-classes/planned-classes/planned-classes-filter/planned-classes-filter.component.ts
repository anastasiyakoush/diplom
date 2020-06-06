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
  @Output() onChangedFilter = new EventEmitter<any[]>();
  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  bsConfig: Partial<BsDatepickerConfig>;
  bsConfig1: Partial<BsDatepickerConfig>;
  dropdownSettings: IDropdownSettings;
  dropdownList2 = [];
  selectedItems2 = [];
  keys = Object.keys;
  form: LessonFilter =  {
    teachersIds: [],
    month: Month.Декабрь,
  };
  lessons: any[];
  Month: typeof Month = Month;
  month = Month;
  months: any = null;

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
    var months = Object.keys(Month);
    this.months = months.slice(months.length / 2);
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
    this.form.groupsIds.push(item.id);
  }

  onItem2Select(item: any) {
    this.form.teachersIds.push(item.id);
  }

  onItem3Select(item: any) {
    this.form.subjectsIds.push(item.id);
  }
  onMonthChange(month) {
  this.form.month = month.id;
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
