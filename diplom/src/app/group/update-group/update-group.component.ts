import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-update-group',
  templateUrl: './update-group.component.html',
  styleUrls: ['./update-group.component.less']
})
export class UpdateGroupComponent implements OnInit {
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
