import { Component, OnInit, Output, EventEmitter, Input } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { EndpointsService } from "src/app/endpoints.service";

@Component({
  selector: "app-update-detailed-syllabus",
  templateUrl: "./update-detailed-syllabus.component.html",
  styleUrls: ["./update-detailed-syllabus.component.less"],
})
export class UpdateDetailedSyllabusComponent implements OnInit {
  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;
  @Input() discId: number;
  @Input() update: boolean;
  @Input() docId: number;
  form = {
    registarcionnyjNomer: "",
    name: "",
    date: new Date(),
    documentType: {},
    link: "",
    uchebnayaDisciplina: {
      id: this.discId,
    },
    authors: [
      {
        id: 0,
      },
    ],
  };
  doctypes: any[];
  doc: any;
  constructor(
    private endpointService: EndpointsService,
    private http: HttpClient
  ) {}
  ngOnInit() {
    if (this.update) {
      this.endpointService.getDocById(this.docId).subscribe((data) => {
        this.form = <any>data;
        this.form.registarcionnyjNomer ="";
        this.form.link = (<any>data).link;
      });
    }
    this.form.uchebnayaDisciplina.id = this.discId;
    this.endpointService
      .getDoctype()
      .subscribe((data) => (this.doctypes = data));
  }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    this.endpointService
      .CreateDocByDiscId(this.form)
      .subscribe(() => this.saveClick.emit());
  }
  addFile = (files: Array<File>) => {
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
        this.form.link = link.link;
        //   if (event.type === HttpEventType.UploadProgress)
        //    this.progress = Math.round((100 * event.loaded) / event.total);
        // else if (event.type === HttpEventType.Response) {
        // this.message = 'Upload success.';
        // this.hotelService.setImagePath(event.body);
        // this.roomService.setImagePath(event.body);
        // }
      });
  };

  onDocChange(data) {
    this.form.documentType = this.doctypes.find((t) => t.id === Number(data));
  }
}
