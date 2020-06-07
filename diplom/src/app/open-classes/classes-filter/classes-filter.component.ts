import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { IDropdownSettings } from "ng-multiselect-dropdown";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import { EndpointsService } from "src/app/endpoints.service";
import { LessonFilter } from '../lesson.model';

@Component({
  selector: "app-classes-filter",
  templateUrl: "./classes-filter.component.html",
  styleUrls: ["./classes-filter.component.less"],
})
export class ClassesFilterComponent implements OnInit {
  @Output() onChangedFilter = new EventEmitter<any[]>();
  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  bsConfig: Partial<BsDatepickerConfig>;
  bsConfig1: Partial<BsDatepickerConfig>;
  dropdownSettings: IDropdownSettings;
  dropdownTeachers = [];
  dropdownGroups = [];
  dropdownSubjects = [];
  selectedTeachers = [];
  selectedGroups = [];
  selectedSubjects = [];
  maxDate = new Date();
  beginDate: Date;
  endDate: Date;
  form : LessonFilter =  {
    teachersIds: [],
    subjectsIds: [],
    groupsIds: this.selectedGroups,
    beginDate: null,
    endDate: null
  };
  lessons: any[];

  constructor(private endpointService: EndpointsService) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
    this.bsConfig1 = Object.assign({}, { containerClass: this.colorTheme });
  }

  ngOnInit() {
    this.endpointService.getSubjects().subscribe(
      (data) =>
        (this.dropdownSubjects = data.map((item) => {
          return {
            name: item.name,
            id: item.id,
          };
        }))
    );
    this.endpointService.getGroup().subscribe(
      (data) =>
        (this.dropdownGroups = data.map((item) => {
          return {
            name: item.name,
            id: item.id,
          };
        }))
    );
    this.endpointService.getTeachers().subscribe((data) => {
      this.dropdownTeachers = data.map((item) => {
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

  onTeachersSelect(item: any) {
    this.form.teachersIds.push(item.id);
  }

  onGroupsSelect(item: any) {
    this.form.groupsIds.push(item.id);
  }

  onSubjectsSelect(item: any) {
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

  restore() {
    this.endpointService.getLessons().subscribe((data:any[])=>{
      this.lessons = data;
      this.onChangedFilter.emit(this.lessons);
    })
  }
}
