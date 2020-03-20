import { Component, OnInit, Output, EventEmitter, Input, OnDestroy } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-update-configuration',
  templateUrl: './update-configuration.component.html',
  styleUrls: ['./update-configuration.component.less']
})
export class UpdateConfigurationComponent implements OnInit, OnDestroy{
  constructor() {
   }

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;

  ngOnInit() {}
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.saveClick.emit()
  }

}
