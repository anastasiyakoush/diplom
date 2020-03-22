import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TeachersComponent } from './teachers/teachers.component';
import { OpenClassesComponent } from './open-classes/open-classes.component';
import { UsersComponent } from './../app/configuration/users/users.component';
import { LoginComponent } from './login/login.component';
import { DisciplinesComponent } from './scientific-and-methodological-support/disciplines/disciplines.component';
import { CurriculumComponent } from './scientific-and-methodological-support/uch-plans/curriculum.component';
import { DetailedTeachersComponent } from './teachers/detailed-teachers/detailed-teachers.component';
import { DetailedClassesComponent } from './open-classes/detailed-classes/detailed-classes.component';
import { UpdateClassesComponent } from './open-classes/update-classes/update-classes.component';
import { PlannedClassesComponent} from './open-classes/planned-classes/planned-classes.component';
import { KomisiiComponent} from './configuration/komisii/komisii.component';
import { DolzhnostiComponent } from './configuration/dolzhnosti/dolzhnosti.component';
import { DoctypeComponent } from './configuration/doctype/doctype.component';
import { GroupsComponent } from './configuration/groups/groups.component';
import { SpecialtyComponent } from './configuration/specialty/specialty.component';
import { AddDocumentComponent } from './scientific-and-methodological-support/add-document/add-document.component';


const routes: Routes = [
  { path: 'authorization/login', component: LoginComponent },
  {
    path: 'users', component: UsersComponent
  },
  {
    path: 'komisii', component: KomisiiComponent
  },
  {
    path: 'dolzhnosti', component: DolzhnostiComponent
  },
  {
    path: 'doctype', component: DoctypeComponent
  },
  {
    path: 'groups', component: GroupsComponent
  },
  {
    path: 'specialty', component: SpecialtyComponent
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
    path: 'uchPlan',
    component: CurriculumComponent
  },
  {
    path: 'addDocument',
    component: AddDocumentComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
