import { Component, OnInit } from '@angular/core';
import { EndpointsService } from 'src/app/endpoints.service';
import { Month } from '../lesson.model';

@Component({
  selector: 'app-compare-classes',
  templateUrl: './compare-classes.component.html',
  styleUrls: ['./compare-classes.component.less']
})
export class CompareClassesComponent implements OnInit {
  lessons: any[] = [];
  constructor(    private endpointService: EndpointsService) {}

  ngOnInit() {
    this.endpointService.getCompareLessons().subscribe((data:any[])=>{
      this.lessons = data;
      data.forEach((lesson, index)=> {
        if(this.lessons[index].teacher ) {
         this.lessons[index].teacher = this.lessons[index].teacher.surname +" "+ lesson.teacher.name  +" "+  lesson.teacher.fatherName;
         this.lessons[index].month = Month[lesson.month];
         this.lessons[index].date = lesson.date;
          this.lessons[index].id = index+1;
        }
         })

     })
  }

}
