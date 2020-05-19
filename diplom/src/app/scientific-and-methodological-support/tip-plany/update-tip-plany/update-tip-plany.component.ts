import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-update-tip-plany',
  templateUrl: './update-tip-plany.component.html',
  styleUrls: ['./update-tip-plany.component.less']
})
export class UpdateTipPlanyComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();

  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  form ={
    date: new Date(),
    name: "",
    laboratornye:0,
    practika:0,
    component: 0,
    all:0,
    kursovoeProectirovanie:0,
    ciklovayaKomissiya: {},
    uchebnyjPlan:{}  }
  bsConfig: Partial<BsDatepickerConfig>;
  cks: any[];
plans: any[];
plan: any;
  constructor( private endpointService: EndpointsService) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
   }

  ngOnInit() {
    this.endpointService.getCK().subscribe(data => (this.cks = data));
    this.endpointService.getPlans().subscribe(data => this.plans = data)
  }

  cancel() {
    this.cancelClick.emit()
  }

  onChange(ck) {
    this.form.ciklovayaKomissiya = ck;
  }
  onPlanChange(plan) {
    this.form.uchebnyjPlan = plan;
  }
  save() {
    this.endpointService.CreateorUpdateSubject(this.form).subscribe(()=>  {this.saveClick.emit()
    location.reload()})
  }

  selectComponent(num) {
    this.form.component = num;
  }
}
