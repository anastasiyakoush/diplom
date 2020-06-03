import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-update-groups',
  templateUrl: './update-groups.component.html',
  styleUrls: ['./update-groups.component.less']
})
export class UpdateGroupsComponent implements OnInit, OnDestroy {

  constructor(private endpointService: EndpointsService) {}

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() update;
  @Input() groupId;
  group: any = {

  };
  plans: any[];

  ngOnInit() {
    this.endpointService.getPlans().subscribe(data => (this.plans = data));
    if (this.update)
      this.endpointService
        .getGroupById(this.groupId)
        .subscribe(data => (this.group = data));
  }
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  onPlanChange(plan) {
    this.group.uchebnyjPlanId = Number(plan);
    this.group.uchebnyjPlan = this.plans.find(p=> p.id === Number(plan));
  }

  save() {
    if (this.update) {
      this.endpointService
        .createGroup(this.group)
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    } else {
      this.endpointService
        .createGroup({ name: this.group.name, uchebnyjPlanId: this.group.uchebnyjPlanId  })
        .subscribe(() => {
          this.saveClick.emit();
          location.reload();
        });
    }
  }
}
