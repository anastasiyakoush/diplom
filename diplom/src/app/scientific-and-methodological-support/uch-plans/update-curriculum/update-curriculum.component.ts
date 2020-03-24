import { Component, OnInit, EventEmitter, Input, Output, OnDestroy } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import {FormControl} from '@angular/forms';
import { EndpointsService } from 'src/app/endpoints.service';


@Component({
  selector: 'app-update-curriculum',
  templateUrl: './update-curriculum.component.html',
  styleUrls: ['./update-curriculum.component.less']
})
export class UpdateCurriculumComponent implements OnInit, OnDestroy {
  addBtn = false;
  spec = false;
  standart = false;
  tipovoi = false;

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;

  bsValue = new Date();
  serializedDate = new FormControl((new Date()).toISOString());
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  form ={
    registarcionnyjNomer: '',
    date: new Date(),
    fileName: 'учебый план'
  }
  bsConfig: Partial<BsDatepickerConfig>;

  constructor( private endpointService: EndpointsService) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });

  }

  ngOnInit() {

  }
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    this.endpointService.createOrUpdatePlan(this.form).subscribe(data =>     this.saveClick.emit()    )
  }

  addFile() {
    this.addBtn = true;
  }

  specSelect() {
    this.spec = true;
    this.standart = false;
    this.tipovoi = false;
  }

  standartSelect() {
    this.standart = true;
    this.spec = false;
    this.tipovoi = false;
  }

  tipovoiSelect() {
    this.tipovoi = true;
    this.standart = false;
    this.spec = false;
  }

}
