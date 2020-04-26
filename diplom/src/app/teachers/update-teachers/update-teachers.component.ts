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
  statuses = Status;
  categories = Category;
  keys = Object.keys;
  @Input() update;
  @Input() teacherId;

  constructor(private endpointService: EndpointsService) {}
  ngOnInit() {
    if (this.update)
      this.endpointService
        .getTeacherById(this.teacherId)
        .subscribe((data:any) => {this.form = data;  this.form.status = data.status;
          this.form.ciklovayaKomissiyaId = data.ciklovayaKomissiya.id;
          this.ck = data.ciklovayaKomissiya;
          this.form.category = data.category});
    this.endpointService.getCK().subscribe(data => (this.cks = data));
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
    this.form.ciklovayaKomissiyaId = ck.id;
  }

  onStatusChange(status) {
    this.form.status = status;
  }

  onCategoryChange(category) {
    this.form.category = category;
  }
}
