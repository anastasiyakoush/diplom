import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  Input,
  OnDestroy
} from "@angular/core";
import { EndpointsService } from "src/app/endpoints.service";
import { THIS_EXPR } from "@angular/compiler/src/output/output_ast";

@Component({
  selector: "app-update-dolzhnosti",
  templateUrl: "./update-dolzhnosti.component.html",
  styleUrls: ["./update-dolzhnosti.component.less"]
})
export class UpdateDolzhnostiComponent implements OnInit, OnDestroy {
  constructor(private endpointService: EndpointsService) {}

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() update;
  @Input() positionId;
  position: any = {
  };

  ngOnInit() {
    if (this.update)
      this.endpointService
        .getPositionById(this.positionId)
        .subscribe(data => (this.position = data));
  }
  ngOnDestroy() {}

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    if (this.update) {
      this.endpointService
        .createPosition({ id: this.position.id, name: this.position.name })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    } else {
      this.endpointService
        .createPosition({ name: this.position.name })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    }
  }
}
