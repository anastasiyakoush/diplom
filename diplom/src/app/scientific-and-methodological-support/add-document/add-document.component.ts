import { Component, OnInit, Output, EventEmitter, Input, OnDestroy  } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import {FormControl} from '@angular/forms';

@Component({
  selector: 'app-add-document',
  templateUrl: './add-document.component.html',
  styleUrls: ['./add-document.component.less']
})
export class AddDocumentComponent implements OnInit, OnDestroy {
  spec = false;
  standart = false;
  discipline = false;

  bsValue = new Date();
  serializedDate = new FormControl((new Date()).toISOString());
  colorTheme = 'theme-blue';
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();

  bsConfig: Partial<BsDatepickerConfig>;

  constructor() {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
   }

  @Output() cancelClick = new EventEmitter<any>();
  @Output() saveClick = new EventEmitter<any>();
  @Input() title: string;

  dropdownSettings: IDropdownSettings;
  dropdownList = [];
  selectedItems = [];
  ngOnInit() {
    this.dropdownList = [
      { item_id: 1, item_text: 'Преподаватель 1' },
      { item_id: 2, item_text: 'Преподаватель 2' },
      { item_id: 3, item_text: 'Преподаватель 3' },
      { item_id: 4, item_text: 'Преподаватель 4' },
    ];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Выбрать все',
      unSelectAllText: 'Отменить все',
      itemsShowLimit: 2,
      allowSearchFilter: true
    };
  }

  ngOnDestroy() { }

  cancel() {
    this.cancelClick.emit();
  }

  save() {
    this.saveClick.emit();
  }

  specSelect() {
    this.spec = true;
    this.standart = false;
  }

  standartSelect() {
    this.standart = true;
    this.spec = false;
  }

  disciplineSelect() {
    this.discipline = true;
    this.standart = false;
    this.spec = false;
  }
}
