import { Component, OnInit, TemplateRef } from '@angular/core';
import { Lesson } from './lesson.model';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EndpointsService } from '../endpoints.service';

@Component({
  selector: 'app-open-classes',
  templateUrl: './open-classes.component.html',
  styleUrls: ['./open-classes.component.less']
})

export class OpenClassesComponent implements OnInit {
  lessons: any[] = [];
  modalRef: BsModalRef;
  searchText: string = "";
  constructor(private router: Router,
    private modalService: BsModalService,
    private endpointService: EndpointsService) {}

  ngOnInit() {
   this.endpointService.getLessons().subscribe((data:any[])=>{
     this.lessons = data;
     data.forEach((lesson, index)=> {
       if(this.lessons[index].teacher ) {
        this.lessons[index].teachername = this.lessons[index].teacher.surname +" "+ lesson.teacher.name  +" "+  lesson.teacher.fatherName;
        this.lessons[index].groupname = lesson.group.name;
        this.lessons[index].uchebnayaDisciplinaname = lesson.uchebnayaDisciplina.name;

       }
        })

    })
  }

  onClick(id: number) {
    this.router.navigate(['openClasses/' + id]);
  }

  addClass(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  search() {
     this.endpointService.SearchPublicLesson(this.searchText).subscribe((data:any[])=> {
      this.lessons = data;
      data.forEach((lesson, index)=> {
        if(this.lessons[index]) {
        this.lessons[index].teacher = lesson.teacher.surname +" "+ lesson.teacher.name  +" "+  lesson.teacher.fatherName;
        this.lessons[index].group = lesson.group;
        this.lessons[index].uchebnayaDisciplina = lesson.uchebnayaDisciplina.name;
        }
      })
     }
     )
  }
}

