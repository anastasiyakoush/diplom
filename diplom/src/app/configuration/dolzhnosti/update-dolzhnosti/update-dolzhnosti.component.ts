import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';

@Component({
  selector: 'app-update-dolzhnosti',
  templateUrl: './update-dolzhnosti.component.html',
  styleUrls: ['./update-dolzhnosti.component.less']
})
export class UpdateDolzhnostiComponent implements OnInit, OnDestroy {

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
