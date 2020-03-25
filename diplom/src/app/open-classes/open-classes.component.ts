import { Component, OnInit, TemplateRef } from '@angular/core';
import { Lesson } from './lesson.model';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EndpointsService } from '../endpoints.service';

@Component({
  selector: 'app-open-classes',
  templateUrl: './open-classes.component.html',
  styleUrls: ['./open-classes.component.less']
})

export class OpenClassesComponent implements OnInit {
  lessons: Lesson[] = [];
  modalRef: BsModalRef;
  searchText: string = "";
  constructor(private router: Router,
    private modalService: BsModalService,
    private endpointService: EndpointsService) {}

  ngOnInit() {
   this.endpointService.getLessons().subscribe((data:Lesson[])=>this.lessons = data)
  }

  onClick(id: number) {
    this.router.navigate(['openClasses/' + id]);
  }

  addClass(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  search() {
     this.endpointService.SearchPublicLesson(this.searchText).subscribe((data:Lesson[])=>this.lessons = data)
  }
}

