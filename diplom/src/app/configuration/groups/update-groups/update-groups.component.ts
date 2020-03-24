import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';

@Component({
  selector: 'app-update-groups',
  templateUrl: './update-groups.component.html',
  styleUrls: ['./update-groups.component.less']
})
export class UpdateGroupsComponent implements OnInit, OnDestroy {

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
