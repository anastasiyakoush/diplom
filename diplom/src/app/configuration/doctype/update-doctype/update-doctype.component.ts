import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';

@Component({
  selector: 'app-update-doctype',
  templateUrl: './update-doctype.component.html',
  styleUrls: ['./update-doctype.component.less']
})
export class UpdateDoctypeComponent implements OnInit, OnDestroy {

  constructor() { }

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;

  ngOnInit() {}
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    this.saveClick.emit();
  }

}
