import { Component, OnInit, TemplateRef } from '@angular/core';
import { Teacher } from './teacher.model';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { EndpointsService } from '../endpoints.service';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.less']
})
export class TeachersComponent implements OnInit {
  teachers: Teacher[] = [];
  searchText ="hi";
  modalRef: BsModalRef;
  constructor(private router: Router,
    private modalService: BsModalService,
    private endpointService: EndpointsService) {}

  ngOnInit() {
    this.endpointService.getTeachers().subscribe((data: any)=>{
      this.teachers = data;
    data.forEach((teacher, index)=> {
      this.teachers[index].name = teacher.surname +" "+ teacher.name  +" "+  teacher.fatherName;
      this.teachers[index].position = teacher.position.name;
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
    })
  }

  onSave() {
    this.modalRef.hide();
    location.reload();
  }
}
