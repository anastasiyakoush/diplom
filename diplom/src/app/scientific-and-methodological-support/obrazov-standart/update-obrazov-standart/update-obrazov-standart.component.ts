import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-update-obrazov-standart',
  templateUrl: './update-obrazov-standart.component.html',
  styleUrls: ['./update-obrazov-standart.component.less']
})
export class UpdateObrazovStandartComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() obrStId: number;
  @Input() update: boolean;
  form ={
    id: 0,
    date: new Date(),
    registarcionnyjNomer: "",
    planType: 0,
    link:'',
    dependencyId:0
   };
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();

  bsConfig: Partial<BsDatepickerConfig>;
  cks: any[];
  ck: any;
  plans: any[];
  plan: any;

constructor( private endpointService: EndpointsService,  private http: HttpClient) {
  this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
   }

  ngOnInit() {
    if(this.update && this.obrStId) {
      this.endpointService.getObrPlanById(this.obrStId).subscribe((data: any)=>{
        this.form = data;
        this.form.date = new Date(data.date);
        this.form.dependencyId = data.specialnost.id;
      })
    }
    this.endpointService.getSpecialnost().subscribe(data => (this.cks = data));
    this.endpointService.getPlans().subscribe(data => this.plans = data)
  }

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.form.planType = 0;
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

  onChange(tp) {
    this.form.dependencyId = Number(tp);
  }

}
