import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';

@Component({
  selector: 'app-update-specialty',
  templateUrl: './update-specialty.component.html',
  styleUrls: ['./update-specialty.component.less']
})
export class UpdateSpecialtyComponent implements OnInit, OnDestroy {

  constructor() { }

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;

  ngOnInit() {
  }
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    this.saveClick.emit();
  }
}
