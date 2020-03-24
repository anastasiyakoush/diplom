import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-update-komisii',
  templateUrl: './update-komisii.component.html',
  styleUrls: ['./update-komisii.component.less']
})
export class UpdateKomisiiComponent implements OnInit, OnDestroy {

  constructor( private endpointService: EndpointsService) { }

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
form = {
  name:''
}
ck:string;
  ngOnInit() {}
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    this.form.name = this.ck;
this.endpointService.createCK(this.form).subscribe(()=>this.saveClick.emit()
)
  }

}
