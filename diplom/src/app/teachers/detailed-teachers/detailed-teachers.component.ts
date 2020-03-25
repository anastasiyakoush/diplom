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

  lessons: Lesson[] = [
    {
      id: 1,
      discipline: "ПССИП",
      topic: "CSS",
      group: "62491",
      teacher: "Терешко",
      date: "26/11/2019"
    },
    {
      id: 1,
      discipline: "ТРПО",
      topic: "Методологии проектирования",
      group: "62493",
      teacher: "Тарасова",
      date: "	15/09/2019"
    },
    {
      id: 1,
      discipline: "СиАОД",
      topic: "Структуры данных",
      group: "7к4911",
      teacher: "Апанасевич",
      date: "26/11/2019"
    }
  ];
  teacher: any;

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

    });
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
