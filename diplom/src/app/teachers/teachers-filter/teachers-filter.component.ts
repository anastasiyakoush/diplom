import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { EndpointsService } from 'src/app/endpoints.service';
import { Status, Category } from 'src/app/enums';

@Component({
  selector: 'app-teachers-filter',
  templateUrl: './teachers-filter.component.html',
  styleUrls: ['./teachers-filter.component.less']
})
export class TeachersFilterComponent implements OnInit {
  cks: any[];
  statuses = Status;
  categories = Category;
  keys = Object.keys;
  ck: any = 0;
  @Output() onChanged = new EventEmitter<any>();
  constructor(private endpointService: EndpointsService) {}
  form = {
    category: 3,
    ciklovayaKomissiya: 0,
    status: 3  };
    teachers: any;
  ngOnInit() {
    this.endpointService.getCK().subscribe(data => {
      this.cks = data;
      this.cks.push({id: 0, name: 'не выбрано'})
    });

  }
  onChange(ck) {
    this.form.ciklovayaKomissiya = ck.id;
  }

  onStatusChange(status) {
    this.form.status = status;
  }

  onCategoryChange(category) {
    this.form.category = category;
  }

  filter() {
    let filterObject = Object.assign({}, this.form);
    filterObject.category = this.form.category === 3? null: this.form.category;
    filterObject.status = this.form.status === 3? null: this.form.status;
    filterObject.ciklovayaKomissiya = this.form.ciklovayaKomissiya === 0? null: this.form.ciklovayaKomissiya;

    this.endpointService.FilterTeacher(filterObject).subscribe((data:any[])=>{
      data.forEach((teacher, index)=> {
        data[index].name = teacher.surname +" "+ teacher.name  +" "+  teacher.fatherName;
        data[index].ciklovayaKomissiya = teacher.ciklovayaKomissiya.name;
        data[index].status = Status[teacher.status];
        data[index].category = Category[teacher.category];
      })
      this.onChanged.emit(data);
    })
  }
  restore() {
    this.endpointService.getTeachers().subscribe((data:any[])=>{
      data.forEach((teacher, index)=> {
        data[index].name = teacher.surname +" "+ teacher.name  +" "+  teacher.fatherName;
        data[index].ciklovayaKomissiya = teacher.ciklovayaKomissiya.name;
        data[index].status = Status[teacher.status];
        data[index].category = Category[teacher.category];
      })
      this.onChanged.emit(data);
    })
  }
}
