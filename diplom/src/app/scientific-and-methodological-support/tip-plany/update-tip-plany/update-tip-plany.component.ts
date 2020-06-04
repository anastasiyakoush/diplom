import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-update-tip-plany',
  templateUrl: './update-tip-plany.component.html',
  styleUrls: ['./update-tip-plany.component.less']
})
export class UpdateTipPlanyComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() tipPlanId: number;
  @Input() update: boolean;
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  form ={
    id: 0,
    date: new Date(),
    registarcionnyjNomer: "",
    planType: 2,
    link:'',
    dependencyId:0
   }
  bsConfig: Partial<BsDatepickerConfig>;
plans: any[];
plan: any;
  constructor( private endpointService: EndpointsService,  private http: HttpClient) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
   }

  ngOnInit() {
    if(this.update && this.tipPlanId) {
      this.endpointService.getTypePlanById(this.tipPlanId).subscribe((data: any)=>{
        this.form = data;
        this.form.planType = 2;
        this.form.date = new Date(data.date)
      })
    }
    this.endpointService.getObrPlans().subscribe((data)=>this.plans = data);
  }

  cancel() {
    this.cancelClick.emit()
  }

  onChange(tp) {
    this.form.dependencyId = tp.id
  }

  save() {
    this.endpointService.createOrUpdatePlan(this.form).subscribe(()=>  {this.saveClick.emit()
    location.reload()})
  }
  addFile = (files: Array<File>) => {
    if (files.length === 0) {
      return;
    }
    const formData = new FormData();

    for (let file of files) {
      formData.append(file.name, file);
    }
    this.http
      .post("https://localhost:44312/api/document/upload", formData, {
        reportProgress: true,
      })
      .subscribe((link: any) => {
        this.form.link = link.link;
      });
  };

}
