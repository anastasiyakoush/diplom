import { Component, OnInit } from "@angular/core";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";

@Component({
  selector: "app-curriculum-filters",
  templateUrl: "./curriculum-filters.component.html",
  styleUrls: ["./curriculum-filters.component.less"]
})
export class CurriculumFiltersComponent implements OnInit {
  colorTheme = "theme-blue";
  bsInlineValue = new Date();
  bsInlineRangeValue: Date[];
  maxDate = new Date();

  bsConfig: Partial<BsDatepickerConfig>;

  constructor() {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsInlineRangeValue = [this.bsInlineValue, this.maxDate];
    this.bsConfig = Object.assign({}, { containerClass: this.colorTheme });
  }

  ngOnInit() {}

/*   dropdownList = [];
  selectedItems = [];
  dropdownSettings = {};

  ngOnInit() {
    this.dropdownList = [
      { id: 1, itemName: "India" },
      { id: 2, itemName: "Singapore" },
      { id: 3, itemName: "Australia" },
      { id: 4, itemName: "Canada" },
      { id: 5, itemName: "South Korea" },
      { id: 6, itemName: "Germany" },
      { id: 7, itemName: "France" },
      { id: 8, itemName: "Russia" },
      { id: 9, itemName: "Italy" },
      { id: 10, itemName: "Sweden" }
    ];
    this.selectedItems = [
      { id: 2, itemName: "Singapore" },
      { id: 3, itemName: "Australia" },
      { id: 4, itemName: "Canada" },
      { id: 5, itemName: "South Korea" }
    ];
    this.dropdownSettings = {
      singleSelection: false,
      text: "Select Countries",
      selectAllText: "Select All",
      unSelectAllText: "UnSelect All",
      enableSearchFilter: true,
      classes: "myclass custom-class"
    };
  }
  onItemSelect(item: any) {
    console.log(item);
    console.log(this.selectedItems);
  }
  OnItemDeSelect(item: any) {
    console.log(item);
    console.log(this.selectedItems);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
  onDeSelectAll(items: any) {
    console.log(items);
  } */
}
