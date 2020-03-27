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
  @Input() ckId: number;
  @Input() update: boolean;
form = {
  id:0,
  name:''
}
ck:string;
  ngOnInit() {
    if (this.update)
    this.endpointService
      .getCKById(this.ckId)
      .subscribe(data => (this.form = data));
  }
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    if (this.update) {
      this.endpointService
        .createCK({ id: this.form.id, name: this.form.name })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    } else {
      this.endpointService
        .createCK({ name: this.form.name })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    }
  }

}
