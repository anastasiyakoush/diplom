import { Component, OnInit, TemplateRef  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less']
})
export class HeaderComponent implements OnInit {
  title: string;
  modalRef: BsModalRef;
  constructor(private route: ActivatedRoute, private router: Router, private modalService: BsModalService) { }

  ngOnInit() {
  }

  addDocument(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
