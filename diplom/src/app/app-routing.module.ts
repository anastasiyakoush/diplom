import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TeachersComponent } from './teachers/teachers.component';
import { OpenClassesComponent } from './open-classes/open-classes.component';

import { LoginComponent } from './login/login.component';
import { SyllabusComponent } from './scientific-and-methodological-support/syllabus/syllabus.component';
import { CurriculumComponent } from './scientific-and-methodological-support/curriculum/curriculum.component';


const routes: Routes = [
  { path: 'authorization/login', component: LoginComponent },
  {
    path: 'teachers',
    component: TeachersComponent
  },
  {
    path: 'openClasses',
    component: OpenClassesComponent
  },
  {
    path: 'support/program',
    component: SyllabusComponent
  },
  {
    path: 'support/plan',
    component: CurriculumComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
