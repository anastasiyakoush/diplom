import { Component, OnInit, Output, EventEmitter, Input } from "@angular/core";
import { Category, Status } from "src/app/enums";
import { EndpointsService } from "src/app/endpoints.service";

@Component({
  selector: "app-update-teachers",
  templateUrl: "./update-teachers.component.html",
  styleUrls: ["./update-teachers.component.less"]
})
export class UpdateTeachersComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  cks: any;
  ck: any;
  form = {
    id: 0,
    surname: "",
    name: "",
    fatherName: "",
    category: Category.Первая,
    ciklovayaKomissiyaId: 0,
    status: 0,
    positionId: 1
  };
  statuses : string[];
  categories = Category;
  keys = Object.keys;
  @Input() update;
  @Input() teacherId;
  ckValue: any;
  options : string[];
  myValue: Category;
  status: Status;
  Category : typeof Category = Category;
  Status : typeof Status = Status;

  constructor(private endpointService: EndpointsService) {}
  ngOnInit() {
    var options = Object.keys(Category);
    this.options = options.slice(options.length / 2);
    var statuses = Object.keys(Status);
    this.statuses = statuses.slice(statuses.length / 2);
    if (this.update)
      this.endpointService
        .getTeacherById(this.teacherId)
        .subscribe((data:any) => {
          this.form.id = data.id;
          this.form.positionId = data.position.id;
          this.form.name = data.name;
          this.form.surname = data.surname;
          this.form.fatherName = data.fatherName;
          this.form.status = data.status;
          this.form.ciklovayaKomissiyaId = data.ciklovayaKomissiya.id;
          this.ckValue = data.ciklovayaKomissiya;
          this.form.category = data.category});
    this.endpointService.getCK().subscribe(data => (this.cks = data));
  }

  onStatusChange(status: string) {
    this.status = Status[status]
    this.form.status = this.status;
  }

  parseValue(value : string) {
    this.myValue = Category[value];
    this.form.category = this.myValue;
  }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    this.endpointService
      .CreateOrUpdateTeacher(this.form)
      .subscribe(data => this.saveClick.emit());
  }

  onChange(ck) {
    this.form.ciklovayaKomissiyaId = Number(ck);
  }

}
