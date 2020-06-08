import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-standart-filter',
  templateUrl: './standart-filter.component.html',
  styleUrls: ['./standart-filter.component.less']
})
export class StandartFilterComponent implements OnInit {
  @Output() onChanged = new EventEmitter<any[]>();
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  bsConfig: Partial<BsDatepickerConfig>;

  tp: any;
  form = {
    specialnostId: null,
    regNumber: '',
    beginDate: null,
    endDate: null,
    tipovoyPlanId: null,
    groupsIds:[]
  }
  standarts: any[];
  specs: any[];
  spec: any = null;

  constructor( private endpointService: EndpointsService, private http: HttpClient) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }

  ngOnInit() {
    this.endpointService.getSpecialnost().subscribe(data => (this.specs = data));
    this.endpointService.getTypePlans().subscribe(data => this.standarts = data);

  }

  onSpecChange(spec) {
    if(spec == null) this.form.specialnostId = null;
    this.form.specialnostId = spec.id;
  }

  onChange(tp) {
    this.form.tipovoyPlanId = tp.id;
  }

  filter() {
    this.endpointService.filterObrPlan(this.form).subscribe((data: any[]) =>
     this.onChanged.emit(data));
  }

  restore() {
    this.endpointService.getObrPlans().subscribe((data: any[]) =>
    this.onChanged.emit(data));
  }
}
