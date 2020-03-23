import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { EndpointsService } from 'src/app/endpoints.service';
import { Category } from 'src/app/enums';

@Component({
  selector: 'app-update-teachers',
  templateUrl: './update-teachers.component.html',
  styleUrls: ['./update-teachers.component.less']
})
export class UpdateTeachersComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  form = {
  Surname:'',
  name:'',
  fathername:'',
  Category: Category.First,
  CiklovayaKomissiyaId: this.endpointService.getCK().subscribe()
}
cks :any;
  constructor( private endpointService: EndpointsService) { }
  ngOnInit() {
    this.endpointService.getCK().subscribe(data => this.cks = data)
  }

  cancel() {
    this.cancelClick.emit()
  }

  save() {
    this.endpointService.CreateOrUpdateTeacher(this.form).subscribe(data =>    this.saveClick.emit()
    )
  }
}
