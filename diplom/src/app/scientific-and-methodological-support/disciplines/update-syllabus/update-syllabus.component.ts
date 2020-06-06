import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-update-syllabus',
  templateUrl: './update-syllabus.component.html',
  styleUrls: ['./update-syllabus.component.less']
})
export class UpdateSyllabusComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() update: boolean;
  @Input() subjectId: number;

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
    if(this.update) {
      this.endpointService.getSubjectById(this.subjectId)
      .subscribe(data=> this.form = <any>data)
    }
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
      location.reload()});
  }

  selectComponent(num) {
    this.form.component = num;
  }
}
