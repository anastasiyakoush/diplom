import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-specialty',
  templateUrl: './specialty.component.html',
  styleUrls: ['./specialty.component.less']
})
export class SpecialtyComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  specs: [];
  searchText: string;
  updateFlag: boolean;
  specId: number;
  constructor(private router: Router, private modalService: BsModalService,
    private endpointService: EndpointsService) { }

  ngOnInit() {
     this.endpointService.getSpecialnost().subscribe((data:any)=> this.specs=data)
  }

  addSpecialty(template: TemplateRef<any>) {
    this.title = 'Добавить специальность';
    this.updateFlag=false;
    this.modalRef = this.modalService.show(template);
  }

  updateSpecialty(template: TemplateRef<any>,id) {
    this.specId = id;
    this.title = 'Редактировать специальность';
    this.updateFlag = true;
    this.modalRef = this.modalService.show(template);
  }

  search() {
    this.endpointService.SearchSpec(this.searchText).subscribe((data:any)=> this.specs=data)
  }

  delete(id) {
    this.endpointService.deleteSpec(id).subscribe(()=> location.reload())
  }
}
