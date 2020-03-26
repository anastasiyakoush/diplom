import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  Input,
  OnDestroy
} from "@angular/core";
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: "app-update-doctype",
  templateUrl: "./update-doctype.component.html",
  styleUrls: ["./update-doctype.component.less"]
})
export class UpdateDoctypeComponent implements OnInit, OnDestroy {
  doctype: any = {
  };;

  constructor(private endpointService: EndpointsService) {}

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() doctypeId: number;
  @Input() update: boolean;
  ngOnInit() {
    console.log(this.doctypeId)
    if (this.update)
      this.endpointService
        .getDoctypeById(this.doctypeId)
        .subscribe(data => (this.doctype = data));
  }
  ngOnDestroy() {}

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    if (this.update) {
      this.endpointService
        .createDoctype({ id: this.doctype.id, name: this.doctype.name })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    } else {
      this.endpointService
        .createDoctype({ name: this.doctype.name })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    }
  }
}
