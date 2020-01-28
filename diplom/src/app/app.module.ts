import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeachersComponent } from './teachers/teachers.component';
import { ScientificAndMethodologicalSupportComponent } from './scientific-and-methodological-support/scientific-and-methodological-support.component';
import { OpenClassesComponent } from './open-classes/open-classes.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { TeachersFilterComponent } from './teachers/teachers-filter/teachers-filter.component';
import { UpdateTeachersComponent } from './teachers/update-teachers/update-teachers.component';
import { DetailedTeachersComponent } from './teachers/detailed-teachers/detailed-teachers.component';
import { DetailedClassesComponent } from './open-classes/detailed-classes/detailed-classes.component';
import { ClassesFilterComponent } from './open-classes/classes-filter/classes-filter.component';
import { UpdateClassesComponent } from './open-classes/update-classes/update-classes.component';
import { SyllabusComponent } from './scientific-and-methodological-support/syllabus/syllabus.component';
import { CurriculumComponent } from './scientific-and-methodological-support/curriculum/curriculum.component';
import { UpdateCurriculumComponent } from './scientific-and-methodological-support/curriculum/update-curriculum/update-curriculum.component';
import { DetailedCurriculumComponent } from './scientific-and-methodological-support/curriculum/detailed-curriculum/detailed-curriculum.component';
import { UpdateSyllabusComponent } from './scientific-and-methodological-support/syllabus/update-syllabus/update-syllabus.component';
import { DetailedSyllabusComponent } from './scientific-and-methodological-support/syllabus/detailed-syllabus/detailed-syllabus.component';

@NgModule({
  declarations: [
    AppComponent,
    TeachersComponent,
    ScientificAndMethodologicalSupportComponent,
    OpenClassesComponent,
    HeaderComponent,
    LoginComponent,
    TeachersFilterComponent,
    UpdateTeachersComponent,
    DetailedTeachersComponent,
    DetailedClassesComponent,
    ClassesFilterComponent,
    UpdateClassesComponent,
    SyllabusComponent,
    CurriculumComponent,
    UpdateCurriculumComponent,
    DetailedCurriculumComponent,
    UpdateSyllabusComponent,
    DetailedSyllabusComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
