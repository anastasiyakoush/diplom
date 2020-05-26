import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';
import { EndpointsService } from 'src/app/endpoints.service';
import { Role } from 'src/app/enums';
import { User } from '../teacher.model';

@Component({
  selector: 'app-update-users',
  templateUrl: './update-users.component.html',
  styleUrls: ['./update-users.component.less']
})
export class UpdateUsersComponent implements OnInit, OnDestroy {

constructor(private endpointService: EndpointsService) {}

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() userId;
  myValue: Role;
  Role : typeof Role = Role;
  options : string[];
  form:User = {
    userName: '',
    role: 0,
    password:''
  };

  ngOnInit() {
    var options = Object.keys(Role);
    this.options = options.slice(options.length / 2);

    if (this.userId)
    this.endpointService
      .getUserById(this.userId)
      .subscribe((data:any) => {
         this.form = data;
      });

  }
  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }
  parseValue(value : string) {
    this.myValue = Role[value];
    this.form.role = this.myValue;
  }
  save() {
    this.endpointService
    .CreateUser(this.form)
    .subscribe(data => this.saveClick.emit());
  }

}
