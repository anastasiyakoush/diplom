import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProgramType } from './programType.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-disciplines',
  templateUrl: './disciplines.component.html',
  styleUrls: ['./disciplines.component.less']
})
export class DisciplinesComponent implements OnInit {
  spec = false;
  course = false;
  programs: any[] = [];

  type: ProgramType;
  modalRef: BsModalRef;
  constructor(private route: ActivatedRoute,
    private modalService: BsModalService,
    private endpointService: EndpointsService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.type = params['type'];
      console.log(this.type);
  });
  this.endpointService.getSubjects().subscribe(data=>{
    this.programs = data
    data.forEach((program:any, index)=> {
      this.programs[index].hours = program.laboratornye + program.practika + program.kursovoeProectirovanie;
    });

  })
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

  addDiscipline(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
