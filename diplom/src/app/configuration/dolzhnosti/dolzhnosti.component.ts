import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-dolzhnosti',
  templateUrl: './dolzhnosti.component.html',
  styleUrls: ['./dolzhnosti.component.less']
})
export class DolzhnostiComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  positions: [];
  searchText: string;
  updateFlag: boolean;
  positionId: number;
  constructor(private router: Router,
    private modalService: BsModalService,
    private endpointService: EndpointsService) { }

  ngOnInit() {
    this.endpointService.getPosition().subscribe((data:any)=> this.positions=data)
  }

  addDolzhnost(template: TemplateRef<any>) {
    this.title = 'Добавить должность';
    this.updateFlag=false;
    this.modalRef = this.modalService.show(template);
  }

  updateDolzhnost(template: TemplateRef<any>, id) {
    this.positionId = id;
    this.title = 'Редактировать должность';
    this.updateFlag=true;
    this.modalRef = this.modalService.show(template);
  }

  search() {
    this.endpointService.SearchPosition(this.searchText).subscribe((data:any)=> this.positions=data)
  }

  delete(id) {
    this.endpointService.deleteposition(id).subscribe(()=> location.reload())
  }
}
