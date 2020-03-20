import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TeachersComponent } from './teachers/teachers.component';
import { OpenClassesComponent } from './open-classes/open-classes.component';

import { LoginComponent } from './login/login.component';
import { ConfigurationComponent } from './configuration/configuration.component';
import { DisciplinesComponent } from './scientific-and-methodological-support/disciplines/disciplines.component';
import { CurriculumComponent } from './scientific-and-methodological-support/uch-plans/curriculum.component';
import { DetailedTeachersComponent } from './teachers/detailed-teachers/detailed-teachers.component';
import { DetailedClassesComponent } from './open-classes/detailed-classes/detailed-classes.component';
import { UpdateClassesComponent } from './open-classes/update-classes/update-classes.component';
import { GroupComponent } from './scientific-and-methodological-support/type-plans/group.component';
import { PlannedClassesComponent} from './open-classes/planned-classes/planned-classes.component'


const routes: Routes = [
  { path: 'authorization/login', component: LoginComponent },
  {
    path: 'configuration', component: ConfigurationComponent
  },
  {
    path: 'teachers',
    component: TeachersComponent
  },
  {
    path: 'teachers/:id',
    component: DetailedTeachersComponent
  },
  {
    path: 'openClasses',
    component: OpenClassesComponent
  },
  {
    path: 'plannedClasses',
    component: PlannedClassesComponent
  },
  {
    path: 'openClasses/:id',
    component: DetailedClassesComponent
  },
  {
    path: 'openClasses/add',
    component: UpdateClassesComponent
  },
  {
    path: 'support/disciplines',
    component: DisciplinesComponent
  },
  {
    path: 'support/:groupId/plan',
    component: CurriculumComponent
  },
  {
    path: 'groups',
    component: GroupComponent
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
