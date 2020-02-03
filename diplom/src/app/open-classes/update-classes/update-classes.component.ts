import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: "app-update-classes",
  templateUrl: "./update-classes.component.html",
  styleUrls: ["./update-classes.component.less"]
})
export class UpdateClassesComponent implements OnInit {
  constructor() {}
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  ngOnInit() {}

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.saveClick.emit()
  }
}
