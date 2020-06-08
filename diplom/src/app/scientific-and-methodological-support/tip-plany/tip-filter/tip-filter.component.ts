import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-tip-filter',
  templateUrl: './tip-filter.component.html',
  styleUrls: ['./tip-filter.component.less']
})
export class TipFilterComponent implements OnInit {
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
obrstndrts: any[]
  bsConfig: Partial<BsDatepickerConfig>;
  @Output() onChanged = new EventEmitter<any[]>();

  tp: any;
  form = {
    regNumber: '',
    beginDate: null,
    endDate: null,
    obrStandartId: null,
  }
  standarts: any[];

  constructor( private endpointService: EndpointsService, private http: HttpClient) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }

  ngOnInit() {
    this.endpointService.getTypePlans().subscribe(data => this.standarts = data);
    this.endpointService.getObrPlans().subscribe(data =>
      this.obrstndrts = data
    );

  }

  onChange(ck) {
    if(ck === null)  this.form.obrStandartId= null;
    this.form.obrStandartId = Number(ck);
  }

  filter() {
    this.endpointService.filterTypePlan(this.form).subscribe((data: any[]) =>
     this.onChanged.emit(data));
  }

  restore() {
    this.endpointService.getTypePlans().subscribe((data: any[]) =>
    this.onChanged.emit(data));
  }
}
