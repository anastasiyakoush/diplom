import { Component, OnInit, TemplateRef } from "@angular/core";
import { Lesson } from "src/app/open-classes/lesson.model";
import { Teacher } from "../teacher.model";
import { BsModalRef, BsModalService } from "ngx-bootstrap";
import { Router, ActivatedRoute } from "@angular/router";
import { EndpointsService } from "src/app/endpoints.service";
import { Status, Category } from "src/app/enums";

@Component({
  selector: "app-detailed-teachers",
  templateUrl: "./detailed-teachers.component.html",
  styleUrls: ["./detailed-teachers.component.less"]
})
export class DetailedTeachersComponent implements OnInit {
  actlesson: boolean = true;
  actsupport: boolean = false;
  id: number;

  lessons: any[] = [
  ];
  teacher: any;
documents: any[];
  modalRef: BsModalRef;
  constructor(
    private router: Router,
    private modalService: BsModalService,
    private route: ActivatedRoute,
    private endpointService: EndpointsService
  ) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = +params["id"];
    });
    this.endpointService.getTeacherById(this.id).subscribe((data: any) => {
      this.teacher = data;
      this.teacher.status = Status[data.status];
      this.teacher.category = Category[data.category];
      this.teacher.name =
        data.surname + " " + data.name + " " + data.fatherName;
      this.teacher.position = data.position.name;
      this.teacher.ciklovayaKomissiya = data.ciklovayaKomissiya.name;

    });
    this.endpointService.getLessonByTeacherId(this.id).subscribe((data: any[]) => {
      this.lessons = data;
      data.forEach((lesson, index)=> {
        if(this.lessons[index].teacher ) {
         this.lessons[index].teacher = this.lessons[index].teacher.surname +" "+ lesson.teacher.name  +" "+  lesson.teacher.fatherName;
         this.lessons[index].group = lesson.group.name;
         this.lessons[index].uchebnayaDisciplinaname = lesson.uchebnayaDisciplina.name;
        }
         })
    })
    this.endpointService.getDocByTeacherId(this.id).subscribe((data: any[]) => {
this.documents = data;
data.forEach((doc, index)=> {
  if(this.documents[index].authors ) {
   this.documents[index].name = this.documents[index].name;
   this.documents[index].authors = doc.authors;
  }
   })
    })
  }

  change(num: number) {
    if (num === 1) {
      this.actlesson = true;
      this.actsupport = false;
    } else {
      this.actlesson = false;
      this.actsupport = true;
    }
  }

  UpdateTeacher(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
