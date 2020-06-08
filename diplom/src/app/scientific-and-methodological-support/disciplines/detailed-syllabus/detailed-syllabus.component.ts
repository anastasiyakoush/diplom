import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { setMonth } from 'ngx-bootstrap/chronos/utils/date-setters';
import { EndpointsService } from 'src/app/endpoints.service';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-detailed-syllabus',
  templateUrl: './detailed-syllabus.component.html',
  styleUrls: ['./detailed-syllabus.component.less']
})
export class DetailedSyllabusComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  id: number;
  docs: any[];
  update: boolean;
  docId: number;
  constructor(private router: Router,
    private route: ActivatedRoute,
    private auth: AuthService,
    private endpointService: EndpointsService,
     private modalService: BsModalService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = +params["id"];
    });
    this.endpointService.getDocByDiscId(this.id).subscribe((data)=> this.docs = data)
  }

  download(link) {
    this.endpointService.documentDownload(link)
  }

  addDocument(template: TemplateRef<any>) {
    this.update = false;
    this.title = 'Добавить документ';
    this.modalRef = this.modalService.show(template);
  }

  updateDocument(template: TemplateRef<any>, id) {
    this.update = true;
    this.docId = id;
    this.title = 'Редактировать документ';
    this.modalRef = this.modalService.show(template);
  }

  onClick(id: number) {
  }

  delete(id) {
    this.endpointService.deleteDocById(id).subscribe(()=> location.reload() )
  }

  save() {
    this.modalRef.hide();
    location.reload();
  }
}
