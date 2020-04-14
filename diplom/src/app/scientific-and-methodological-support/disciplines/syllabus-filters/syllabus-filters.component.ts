import { Component, OnInit, EventEmitter, Output } from "@angular/core";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import { HttpClient } from "@angular/common/http";
import { EndpointsService } from "src/app/endpoints.service";

@Component({
  selector: "app-syllabus-filters",
  templateUrl: "./syllabus-filters.component.html",
  styleUrls: ["./syllabus-filters.component.less"]
})
export class SyllabusFiltersComponent implements OnInit {
  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  @Output() onChanged = new EventEmitter<any>();
  bsConfig: Partial<BsDatepickerConfig>;
  cks: any[];
  plans: any[];
  plan: any;
  form = {
    regNumber: "",
    specialnostId: 3,
    component: 0,
    lrStart: 0,
    lrEnd: 0,
    prStart: 0,
    prEnd: 0,
    kpStart: 0,
    kpEnd: 0,
    uchebnyjPlanId: 0
  };
  disciplines: any[];

  constructor(
    private endpointService: EndpointsService,
    private http: HttpClient
  ) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }

  onPlanChange(plan) {
    this.form.uchebnyjPlanId = plan.шв;
  }
  ngOnInit() {
    this.endpointService.getPlans().subscribe(data => (this.plans = data));
  }
  filter() {
    this.endpointService.FilterSubject(this.form).subscribe((data: any[]) => {
      this.disciplines = data;
      data.forEach((program: any, index) => {
        this.disciplines[index].hours =
          program.laboratornye +
          program.practika +
          program.kursovoeProectirovanie;
      });
      this.onChanged.emit(this.disciplines);
    });
  }
}
