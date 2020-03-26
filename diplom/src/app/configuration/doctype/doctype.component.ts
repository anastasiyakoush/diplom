import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-doctype',
  templateUrl: './doctype.component.html',
  styleUrls: ['./doctype.component.less']
})
export class DoctypeComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  doctypes: [];
  updateFlag: boolean;
  doctypeId: any;
  searchText: string;
  constructor(private router: Router, private modalService: BsModalService,
    private endpointService: EndpointsService) { }

  ngOnInit() {
    this.endpointService.getDoctype().subscribe((data:any)=> this.doctypes=data)
  }

  addType(template: TemplateRef<any>) {
    this.title = 'Добавить тип документа';
    this.updateFlag=false;
    this.modalRef = this.modalService.show(template);
  }

  updateType(template: TemplateRef<any>, id: number) {
    this.doctypeId = id;
    this.title = 'Редактировать тип документа';
    this.updateFlag=true;
    this.modalRef = this.modalService.show(template);
  }

  search() {
   this.endpointService.SearchDoctype(this.searchText).subscribe((data:any)=> this.doctypes=data)
  }

  delete(id) {
    this.endpointService.deleteDoctype(id).subscribe(()=> location.reload())
  }
}
