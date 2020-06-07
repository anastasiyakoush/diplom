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
  @Input() update: boolean;

  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();
  bsConfig: Partial<BsDatepickerConfig>;
  disciplines: any[];
  disciplin: any;
  groups: any;
  group: any;
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

    if (this.update ) {

      this.endpointService.getLessonById(this.lessonId).subscribe((lesson) => {
        this.form = <any>lesson;
        this.form.date = new Date(lesson.date);
      this.form.teacher = lesson.teacher;
      this.selectedteacher = lesson.teacher;
      this.group = lesson.group;
      this.form.group = lesson.group;
      })
    }
  }

  cancel() {
    this.cancelClick.emit();
  }

  addFile = (files: Array<File>, metodic: boolean) => {
    debugger
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
    debugger
    this.form.uchebnayaDisciplina = this.disciplines.find(t=> t.id === Number(disciplina));
  }

  onTeacherChange(teacher) {
    debugger
    this.form.teacher = this.teachers.find(t=> t.id === Number(teacher));
  }

  onGroupChange(group) {
    debugger
    this.form.group = this.groups.find(t=> t.id === Number(group));;
  }

  save() {
    this.endpointService
      .createOrUpdateLesson(this.form)
      .subscribe(() => this.saveClick.emit());
    location.reload();
  }
}
