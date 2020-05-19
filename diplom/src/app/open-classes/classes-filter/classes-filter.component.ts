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
  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  dropdownSettings: IDropdownSettings;
  dropdownList1 = [];
  dropdownList2 = [];
  dropdownList3 = [];
  selectedItems1 = [];
  selectedItems2 = [];
  selectedItems3 = [];
  maxDate = new Date();
  beginDate: Date;
  endDate: Date;
  form : LessonFilter =  {
    groupIds: this.selectedItems1,
    teachersIds: [],
    subjectsIds: [],
    beginDate: null,
    endDate: null
  };
  bsConfig: Partial<BsDatepickerConfig>;
  bsConfig1: Partial<BsDatepickerConfig>;
  lessons: any[];
  @Output() onChangedFilter = new EventEmitter<any[]>();

  constructor(private endpointService: EndpointsService) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
    this.bsConfig1 = Object.assign({}, { containerClass: this.colorTheme });
  }

  ngOnInit() {
    this.endpointService.getSubjects().subscribe(
      (data) =>
        (this.dropdownList3 = data.map((item) => {
          return {
            name: item.name,
            id: item.id,
          };
        }))
    );
    this.endpointService.getGroup().subscribe(
      (data) =>
        (this.dropdownList1 = data.map((item) => {
          return {
            name: item.name,
            id: item.id,
          };
        }))
    );
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

/*   restore() {
    this.endpointService.getTeachers().subscribe((data:any[])=>{
      data.forEach((teacher, index)=> {
        data[index].name = teacher.surname +" "+ teacher.name  +" "+  teacher.fatherName;
        data[index].ciklovayaKomissiya = teacher.ciklovayaKomissiya.name;
        data[index].status = Status[teacher.status];
        data[index].category = Category[teacher.category];
      })
      this.onChanged.emit(data);
    })
  } */
}
