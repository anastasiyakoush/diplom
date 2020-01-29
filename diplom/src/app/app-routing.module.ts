import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TeachersComponent } from './teachers/teachers.component';
import { OpenClassesComponent } from './open-classes/open-classes.component';
import { ScientificAndMethodologicalSupportComponent } from './scientific-and-methodological-support/scientific-and-methodological-support.component';
import { LoginComponent } from './login/login.component';


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
    path: 'support',
    component: ScientificAndMethodologicalSupportComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
