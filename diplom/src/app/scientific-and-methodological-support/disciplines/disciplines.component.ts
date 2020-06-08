import { Component, OnInit, TemplateRef } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { disciplina } from './disciplina.model';
import { ProgramType } from "./programType.model";
import { BsModalRef, BsModalService } from "ngx-bootstrap";
import { EndpointsService } from "src/app/endpoints.service";
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: "app-disciplines",
  templateUrl: "./disciplines.component.html",
  styleUrls: ["./disciplines.component.less"]
})
export class DisciplinesComponent implements OnInit {
  disciplina:any;
  spec = false;
  course = false;
  programs: any[] = [];
  title: string;
  update: boolean;
  searchText: string;
  component: ProgramType;
  modalRef: BsModalRef;
  constructor(
    private route: ActivatedRoute,
    private modalService: BsModalService,
    private auth: AuthService,
    private endpointService: EndpointsService,
    private router: Router
  ) {}

  ngOnInit() {
    this.endpointService.getSubjects().subscribe(data => {
      this.programs = data;
      data.forEach((program: any, index) => {
        this.programs[index].hours =
        program.laboratornye +'/'+
        program.practika + '/'+
        program.kursovoeProectirovanie + '/'+program.all;
      });
    });
  }

  addDiscipline(template: TemplateRef<any>) {
    this.title = 'Добавить документ';
    this.update = false;
    this.modalRef = this.modalService.show(template);
  }

  updateDiscipline(template: TemplateRef<any>, id) {
    this.disciplina = id;
    this.update = true;
    this.title = 'Редактировать документ';
    this.modalRef = this.modalService.show(template);
  }

  filter($event) {
    console.log($event);
    this.programs = $event;
  }
  selectChanged(num: number) {
    if (num === 1) {
      this.spec = true;
    } else if (num === 2) {
      this.course = true;
    } else {
      this.spec = false;
      this.course = false;
    }
  }

  search() {
    this.endpointService.SearchSubject(this.searchText).subscribe((data: any) => {
      this.programs = data;
      data.forEach((program: any, index) => {
        this.programs[index].hours =
        program.laboratornye +'/'+
        program.practika + '/'+
        program.kursovoeProectirovanie + '/'+program.all;
      });
    });
  }

  onClick(id: number) {
    this.router.navigate(["detailedSyllabus/" + id]);
  }

  delete(id) {
    this.endpointService.DeleteSubject(id).subscribe(()=> location.reload() )
  }
}
