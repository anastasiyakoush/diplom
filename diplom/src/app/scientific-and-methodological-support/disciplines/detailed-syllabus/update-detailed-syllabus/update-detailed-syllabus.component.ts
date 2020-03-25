import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-update-detailed-syllabus',
  templateUrl: './update-detailed-syllabus.component.html',
  styleUrls: ['./update-detailed-syllabus.component.less']
})
export class UpdateDetailedSyllabusComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.saveClick.emit()
  }
}
