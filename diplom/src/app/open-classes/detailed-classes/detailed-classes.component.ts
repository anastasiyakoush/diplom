import { Component, OnInit, TemplateRef } from '@angular/core';
import { Teacher } from 'src/app/teachers/teacher.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detailed-classes',
  templateUrl: './detailed-classes.component.html',
  styleUrls: ['./detailed-classes.component.less']
})
export class DetailedClassesComponent implements OnInit {

  teachers: Teacher[] = [ ];

  modalRef: BsModalRef;
  constructor(private router: Router,private modalService: BsModalService) {}

  ngOnInit() {
  }

  updateLesson(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
