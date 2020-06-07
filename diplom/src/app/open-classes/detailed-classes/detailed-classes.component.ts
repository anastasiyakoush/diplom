import { Component, OnInit, TemplateRef } from '@angular/core';
import { Teacher } from 'src/app/teachers/teacher.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { EndpointsService } from 'src/app/endpoints.service';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-detailed-classes',
  templateUrl: './detailed-classes.component.html',
  styleUrls: ['./detailed-classes.component.less']
})
export class DetailedClassesComponent implements OnInit {

  lesson: any = [ ];
  update: boolean;
  modalRef: BsModalRef;
  id: number;
  constructor(private router: Router,
    private modalService: BsModalService,
    private route: ActivatedRoute,
    private auth: AuthService,
    private endpointService: EndpointsService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = +params["id"];
    });
    this.endpointService.getLessonById(this.id).subscribe((lesson)=>{
      this.lesson = lesson;
    })
  }

  download(link) {
    this.endpointService.documentDownload(link)
  }

  updateLesson(template: TemplateRef<any>) {
    this.update = true;
    this.modalRef = this.modalService.show(template);
  }

  deleteLesson() {
    this.endpointService.DeleteLesson(this.id).subscribe(() => this.router.navigate(['openClasses']));
  }

}
