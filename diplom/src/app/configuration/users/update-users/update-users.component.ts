import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';

@Component({
  selector: 'app-update-users',
  templateUrl: './update-users.component.html',
  styleUrls: ['./update-users.component.less']
})
export class UpdateUsersComponent implements OnInit, OnDestroy {

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
