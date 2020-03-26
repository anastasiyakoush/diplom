import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-update-specialty',
  templateUrl: './update-specialty.component.html',
  styleUrls: ['./update-specialty.component.less']
})
export class UpdateSpecialtyComponent implements OnInit, OnDestroy {

  constructor(private endpointService: EndpointsService) {}

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() specId: number;
  @Input() update;
  spec: any = {}
  ngOnInit() {
    if (this.update)
      this.endpointService
        .getSpecById(this.specId)
        .subscribe(data => (this.spec = data));
  }
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    if (this.update) {
      this.endpointService
        .createSpec({ id: this.spec.id, name: this.spec.name, code: this.spec.code })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    } else {
      this.endpointService
        .createSpec({ name: this.spec.name, code: this.spec.code })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    }
  }
}
