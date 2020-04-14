import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { EndpointsService } from 'src/app/endpoints.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-curriculum-filters',
  templateUrl: './curriculum-filters.component.html',
  styleUrls: ['./curriculum-filters.component.less']
})
export class CurriculumFiltersComponent implements OnInit {
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();

  bsConfig: Partial<BsDatepickerConfig>;
  @Output() onChanged = new EventEmitter<any>();


  form ={
    registarcionnyjNomer: '',
    date: new Date(),
    planType: 1,
    link: '',
    dependencyId: 2

  }

  constructor( private endpointService: EndpointsService,private http: HttpClient) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }

  dropdownSettings: IDropdownSettings;
  dropdownList = [];
  selectedItems = [];
  ngOnInit() {
  }
  filter() {
    this.endpointService.FilterSubject(this.form).subscribe((data:any[])=>
     data.forEach((teacher, index)=> {
        data[index].name = teacher.surname +" "+ teacher.name  +" "+  teacher.fatherName;
        data[index].ciklovayaKomissiya = teacher.ciklovayaKomissiya.name;
      })
   //   this.onChanged.emit(data);
  )
  }
}
