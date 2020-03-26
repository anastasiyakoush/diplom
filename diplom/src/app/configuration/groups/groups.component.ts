import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { EndpointsService } from 'src/app/endpoints.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.less']
})
export class GroupsComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  groups: [];
  searchText: string;
  updateFlag: boolean;
  groupId: number;
  constructor(private router: Router, private modalService: BsModalService,
    private endpointService: EndpointsService) { }

  ngOnInit() {
    this.endpointService.getGroup().subscribe((data:any)=> this.groups=data)

  }

  addGroup(template: TemplateRef<any>) {
    this.title = 'Добавить группу';
    this.updateFlag=false;
    this.modalRef = this.modalService.show(template);
  }

  updateGroup(template: TemplateRef<any>,id) {
    this.groupId = id;
    this.title = 'Редактировать группу';
    this.updateFlag=true;
    this.modalRef = this.modalService.show(template);
  }

  search() {
    this.endpointService.SearchGroup(this.searchText).subscribe((data:any)=> this.groups=data)
  }

  delete(id) {
    this.endpointService.deleteGroup(id).subscribe(()=> location.reload())
  }
}
