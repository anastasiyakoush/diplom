import { Component, OnInit, TemplateRef } from "@angular/core";
import { Lesson, Month } from "./../lesson.model";
import { Router } from "@angular/router";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { EndpointsService } from "src/app/endpoints.service";
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: "app-planned-classes",
  templateUrl: "./planned-classes.component.html",
  styleUrls: ["./planned-classes.component.less"]
})
export class PlannedClassesComponent implements OnInit {
  lessons: any[] = [];
  modalRef: BsModalRef;
  searchText: string = "";
  title: string;
  update: boolean;
  lessonId: number;
  constructor(
    private router: Router,
    private modalService: BsModalService,
    private auth: AuthService,
    private endpointService: EndpointsService
  ) {}

  ngOnInit() {
    this.endpointService.getPlannedLessons().subscribe((data: any[]) => {
      this.lessons = data;
      data.forEach((lesson, index) => {
        if (this.lessons[index].teacher) {
          this.lessons[index].teacher =
            this.lessons[index].teacher.surname +
            " " +
            lesson.teacher.name +
            " " +
            lesson.teacher.fatherName;
            this.lessons[index].month = Month[lesson.month],
          this.lessons[index].status = lesson.status
            ? "планируется"
            : "проведено";
        }
      });
    });
  }

  addClass(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  addLesson(template: TemplateRef<any>) {
    this.title = 'Добавить запланированное занятие';
    this.update = false;
    this.modalRef = this.modalService.show(template);
  }

  updateLesson(template: TemplateRef<any>, id) {
    this.lessonId = id;
    this.update = true;
    this.title = 'Редактировать запланированное занятие';
    this.modalRef = this.modalService.show(template);
  }

 delete(id) {
    this.endpointService.DeletePlannedPublicLesson(id).subscribe(()=> location.reload() )
  }

  search() {
    this.endpointService
      .SearchPlannedPublicLesson(this.searchText)
      .subscribe((data: any[]) => {
        this.lessons = data;
        data.forEach((lesson, index) => {
          if (this.lessons[index].teacher) {
            this.lessons[index].teacher =
              this.lessons[index].teacher.surname +
              " " +
              lesson.teacher.name +
              " " +
              lesson.teacher.fatherName;
            this.lessons[index].status = lesson.status
              ? "планируются"
              : "проведено";
          }
        });
      });
  }
}
