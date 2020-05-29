import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Teacher } from './teacher.model';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { EndpointsService } from '../endpoints.service';
import { Status, Category } from '../enums';
import { TeachersFilterComponent } from './teachers-filter/teachers-filter.component';
import { ThrowStmt } from '@angular/compiler';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.less']
})
export class TeachersComponent implements OnInit {
  teachers: any[] = [];
  searchText ="";
  modalRef: BsModalRef;
  @ViewChild('app-teachers-filter', {static: false}) teacherFilter: TeachersFilterComponent;
  constructor(private router: Router, private modalService: BsModalService,
     private endpointService: EndpointsService,
     private auth: AuthService
    ) {}

  ngOnInit() {
    this.endpointService.getTeachers().subscribe((data: any)=>{
      this.teachers = data;
    data.forEach((teacher, index)=> {
      this.teachers[index].name = teacher.surname +" "+ teacher.name  +" "+  teacher.fatherName;
      this.teachers[index].ciklovayaKomissiya = teacher.ciklovayaKomissiya.name;
      this.teachers[index].status = Status[teacher.status];
      this.teachers[index].category = Category[teacher.category];
    });
    })  }

  onClick(id: number) {
    this.router.navigate(['teachers/' + id]);
  }

  addTeacher(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  search() {
    this.endpointService.SearchTeacher(this.searchText).subscribe((data: any) => {
      this.teachers = data;
      for(let index=0;index<=this.teachers.length;index++) {
        this.teachers[index].name = this.teachers[index].surname +" "+ this.teachers[index].name  +" "+  this.teachers[index].fatherName;
        this.teachers[index].ciklovayaKomissiya = this.teachers[index].ciklovayaKomissiya? this.teachers[index].ciklovayaKomissiya.name : '';
        this.teachers[index].status = Status[this.teachers[index].status];
        this.teachers[index].category = Category[this.teachers[index].category];
      }
      })
  }

  onSave() {
    this.modalRef.hide();
    location.reload();
  }

  filterChange($event) {
    console.log($event)
    this.teachers = $event;
  }
}
