import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-update-teachers',
  templateUrl: './update-teachers.component.html',
  styleUrls: ['./update-teachers.component.less']
})
export class UpdateTeachersComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;

  constructor() { }
  ngOnInit() {}

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.saveClick.emit()
  }
}
