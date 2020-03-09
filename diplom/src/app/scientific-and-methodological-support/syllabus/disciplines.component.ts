import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProgramType } from './programType.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Disciplina } from './disciplina.model';

@Component({
  selector: 'app-disciplines',
  templateUrl: './disciplines.component.html',
  styleUrls: ['./disciplines.component.less']
})
export class DisciplinesComponent implements OnInit {
  spec = false;
  course = false;
  programs: Disciplina[] = [
    {
      id: 1,
      nomer: 11,
      name: 'математика',
      plan: 'ссылка',
      hours: '170/12/23'
    },
    {
      id: 1,
      nomer: 15,
      name: 'КПИЯП',
      plan: 'ссылка',
      hours: '170/12/23'
    },
    {
      id: 1,
      nomer: 21,
      name: 'ОТ',
      plan: 'ссылка',
      hours: '170/12/23'
    }
  ];

  type: ProgramType;
  modalRef: BsModalRef;
  constructor(private route: ActivatedRoute, private modalService: BsModalService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.type = params['type'];
      console.log(this.type);
  });
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

  addProgram(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
