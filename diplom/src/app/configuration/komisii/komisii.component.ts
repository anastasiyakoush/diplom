import { Component, OnInit, TemplateRef } from "@angular/core";
import { Router } from "@angular/router";
import { BsModalRef, BsModalService } from "ngx-bootstrap";
import { EndpointsService } from "src/app/endpoints.service";

@Component({
  selector: "app-komisii",
  templateUrl: "./komisii.component.html",
  styleUrls: ["./komisii.component.less"]
})
export class KomisiiComponent implements OnInit {
  title: string;
  komisia = [];
  modalRef: BsModalRef;
  searchText: string;
  constructor(
    private router: Router,
    private modalService: BsModalService,
    private endpointService: EndpointsService
  ) {}

  ngOnInit() {
    this.endpointService
      .getCK()
      .subscribe((data: any) => (this.komisia = data));
  }

  addKomisii(template: TemplateRef<any>) {
    this.title = "Добавить цикловую комиссию";
    this.modalRef = this.modalService.show(template);
  }

  updateKomisii(template: TemplateRef<any>) {
    this.title = "Редактировать цикловую комиссию";
    this.modalRef = this.modalService.show(template);
  }
  saveClick() {
    this.modalRef.hide();
    location.reload();
  }

  delete(id) {
    this.endpointService.deleteCK(id).subscribe(() => location.reload());
  }

  search() {
    this.endpointService.searchCK(this.searchText).subscribe((data:any)=> this.komisia = data)
  }
}
