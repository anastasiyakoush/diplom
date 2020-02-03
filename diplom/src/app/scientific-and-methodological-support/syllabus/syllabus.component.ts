import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProgramType } from './ProgramType.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Program } from './Program.model';

@Component({
  selector: 'app-syllabus',
  templateUrl: './syllabus.component.html',
  styleUrls: ['./syllabus.component.less']
})
export class SyllabusComponent implements OnInit {
  programs: Program[] = [
    {
      id: 1,
      nomer: 131,
      date: '26/11/2019',
      hours: '170/12/23'
    },
    {
      id: 2,
      nomer: 171,
      date: '15/09/2019',
      hours: '	280/23/12'
    },
    {
      id: 3,
      nomer: 191,
      date: '26/11/2019',
      hours: '170/12/23'
    }
  ];

  type: ProgramType;
  modalRef: BsModalRef;
  constructor(private route: ActivatedRoute,private modalService: BsModalService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.type = params['type'];
      console.log(this.type)
  });
  }

  addProgram(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
