import { Component, OnInit, Output, EventEmitter, Input } from "@angular/core";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";
import { EndpointsService } from "src/app/endpoints.service";
import { Teacher } from "src/app/teachers/teacher.model";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-update-classes",
  templateUrl: "./update-classes.component.html",
  styleUrls: ["./update-classes.component.less"],
})
export class UpdateClassesComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() lessonId: number;

  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  bsConfig: Partial<BsDatepickerConfig>;
  disciplines: any[];
  groups: any;
  group: any;
  disciplin: any;
  selectedteacher: any;
  teachers: Teacher[] = [];
  form = {
    teacher: {},
    metodicheskieNarabotki: "",
    date: new Date(),
    topic: "",
    planUroka: "",
    uchebnayaDisciplina: {},
    group: {},
  };

  constructor(
    private endpointService: EndpointsService,
    private http: HttpClient
  ) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }

  ngOnInit() {
    this.endpointService.getTeachers().subscribe((data: any[]) => {
      this.teachers = data;
      data.forEach((teacher, index) => {
        this.teachers[index].name =
          teacher.surname + " " + teacher.name + " " + teacher.fatherName;
      });
    });
    this.endpointService.getSubjects().subscribe((data) => {
      this.disciplines = data;
    });
    this.endpointService
      .getGroup()
      .subscribe((data: any) => (this.groups = data));

    if (this.lessonId) {
      this.endpointService.getLessonById(this.lessonId).subscribe((lesson) => {
      this.form.date = new Date(lesson.date);
      this.form.teacher = lesson.teacher;
      this.selectedteacher = lesson.teacher;
      this.group = lesson.group
      this.form.group = lesson.group;
      })
    }
  }

  cancel() {
    this.cancelClick.emit();
  }

  addFile = (files: Array<File>, metodic: boolean) => {
    if (files.length === 0) {
      return;
    }
    const formData = new FormData();

    for (let file of files) {
      formData.append(file.name, file);
    }

    this.http
      .post("https://localhost:44312/api/document/upload", formData, {
        reportProgress: true,
      })
      .subscribe((link: any) => {
        if (metodic) {
          this.form.metodicheskieNarabotki = link.link;
        } else this.form.planUroka = link.link;
      });
  };

  onDiscChange(disciplina) {
    this.form.uchebnayaDisciplina = disciplina;
  }

  onTeacherChange(teacher) {
    this.form.teacher = teacher;
  }

  onGroupChange(group) {
    this.form.group = group;
  }

  save() {
    this.endpointService
      .createOrUpdateLesson(this.form)
      .subscribe(() => this.saveClick.emit());
  }
}
