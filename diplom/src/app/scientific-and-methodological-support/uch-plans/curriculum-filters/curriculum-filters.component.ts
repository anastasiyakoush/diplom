import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-curriculum-filters',
  templateUrl: './curriculum-filters.component.html',
  styleUrls: ['./curriculum-filters.component.less']
})
export class CurriculumFiltersComponent implements OnInit {
  @Output() onChanged = new EventEmitter<any[]>();

  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  bsConfig: Partial<BsDatepickerConfig>;

  form = {
    regNumber: '',
    beginDate: null,
    endDate: null,
    tipovoyPlanId: null,
    groupIds: []
    };
  plans: any[];
  tp: any = null;

  constructor( private endpointService: EndpointsService, private http: HttpClient) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }

  dropdownSettings: IDropdownSettings;
  dropdownList = [];
  selectedItems = [];
  ngOnInit() {
    this.endpointService.getTypePlans().subscribe(data => {this.plans = data;});
    this.endpointService.getGroup().subscribe(
      (data) =>
        (this.dropdownList = data.map((item) => {
          return {
            name: item.name,
            id: item.id,
          };
        }))
    );
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Выбрать все',
      unSelectAllText: 'Отменить все',
      itemsShowLimit: 3,
      allowSearchFilter: true,
    };
  }

  onChange(tp) {
    this.form.tipovoyPlanId = tp.id;
  }

  onItem1Select(item: any) {
    this.form.groupIds.push(item.id);
  }

  filter() {
    this.endpointService.filterPlan(this.form).subscribe((data: any[]) =>
     this.onChanged.emit(data));
  }

  restore() {
    this.endpointService.getPlans().subscribe((data: any[]) =>
    this.onChanged.emit(data));
  }
}
