import { Component, OnInit, EventEmitter, Output } from "@angular/core";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import { HttpClient } from "@angular/common/http";
import { EndpointsService } from "src/app/endpoints.service";
import { Komponent } from "src/app/enums";

@Component({
  selector: "app-syllabus-filters",
  templateUrl: "./syllabus-filters.component.html",
  styleUrls: ["./syllabus-filters.component.less"],
})
export class SyllabusFiltersComponent implements OnInit {
  @Output() onChanged = new EventEmitter<any>();
  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  bsConfig: Partial<BsDatepickerConfig>;
  cks: any[];
  plans: any[];
  plan: any = null;
  form = {
    specialnostId: null,
    component: 3,
    lrStart: null,
    lrEnd: null,
    prStart: null,
    prEnd: null,
    kpStart: null,
    kpEnd: null,
    allStart: null,
    allEnd: null,
    uchebnyjPlanId: null,
  };
  disciplines: any[];
  specs: any[];
  spec: any = null;
  sp: any;
  Komponent: typeof Komponent = Komponent;
  components: string[];

  constructor(
    private endpointService: EndpointsService,
    private http: HttpClient
  ) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }
  ngOnInit() {
    this.endpointService.getPlans().subscribe((data) => (this.plans = data));
    this.endpointService
      .getSpecialnost()
      .subscribe((data) => (this.specs = data));

    var components = Object.keys(Komponent);
    this.components = components.slice(components.length / 2);
  }

  onPlanChange(plan) {
    if (plan) {
      this.form.uchebnyjPlanId = plan.id;
    } else this.form.uchebnyjPlanId = null;
  }

  onSpecChange(spec) {
    if (spec) {
    this.form.specialnostId = spec.id;
    } else  this.form.specialnostId = null;
  }

  onComponentChange(name:string) {
this.form.component = Komponent[name];
  }

  filter() {
    if(this.form.component ===3 ){
      this.form.component = null;
    }
    this.endpointService.FilterSubject(this.form).subscribe((data: any[]) => {
      this.disciplines = data;
      data.forEach((program: any, index) => {
        this.disciplines[index].hours =
          program.laboratornye +
          "/" +
          program.practika +
          "/" +
          program.kursovoeProectirovanie +
          "/" +
          program.all;
      });
      this.onChanged.emit(this.disciplines);
    });
  }

  restore() {
    this.endpointService.getSubjects().subscribe((data) => {
      this.disciplines = data;
      data.forEach((program: any, index) => {
        this.disciplines[index].hours =
          program.laboratornye +
          "/" +
          program.practika +
          "/" +
          program.kursovoeProectirovanie +
          "/" +
          program.all;
      });
      this.onChanged.emit(this.disciplines);
    });
  }
}
