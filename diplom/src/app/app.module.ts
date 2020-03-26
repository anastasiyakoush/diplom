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
import { DisciplinesComponent } from './scientific-and-methodological-support/disciplines/disciplines.component';
import { CurriculumComponent } from './scientific-and-methodological-support/uch-plans/curriculum.component';
import { UpdateCurriculumComponent } from './scientific-and-methodological-support/uch-plans/update-curriculum/update-curriculum.component';
import { DetailedCurriculumComponent } from './scientific-and-methodological-support/uch-plans/detailed-curriculum/detailed-curriculum.component';
import { UpdateSyllabusComponent } from './scientific-and-methodological-support/disciplines/update-syllabus/update-syllabus.component';
import { DetailedSyllabusComponent } from './scientific-and-methodological-support/disciplines/detailed-syllabus/detailed-syllabus.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ModalModule } from 'ngx-bootstrap';
import { SyllabusFiltersComponent } from './scientific-and-methodological-support/disciplines/syllabus-filters/syllabus-filters.component';
import { CurriculumFiltersComponent } from './scientific-and-methodological-support/uch-plans/curriculum-filters/curriculum-filters.component';
import { PlannedClassesComponent } from './open-classes/planned-classes/planned-classes.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { UsersComponent } from './configuration/users/users.component';
import { KomisiiComponent } from './configuration/komisii/komisii.component';
import { UpdateUsersComponent } from './configuration/users/update-users/update-users.component';
import { DolzhnostiComponent } from './configuration/dolzhnosti/dolzhnosti.component';
import { DoctypeComponent } from './configuration/doctype/doctype.component';
import { GroupsComponent } from './configuration/groups/groups.component';
import { SpecialtyComponent } from './configuration/specialty/specialty.component';
import { UpdateDoctypeComponent } from './configuration/doctype/update-doctype/update-doctype.component';
import { UpdateDolzhnostiComponent } from './configuration/dolzhnosti/update-dolzhnosti/update-dolzhnosti.component';
import { UpdateGroupsComponent } from './configuration/groups/update-groups/update-groups.component';
import { UpdateKomisiiComponent } from './configuration/komisii/update-komisii/update-komisii.component';
import { UpdateSpecialtyComponent } from './configuration/specialty/update-specialty/update-specialty.component';
import { AddDocumentComponent } from './scientific-and-methodological-support/add-document/add-document.component';
import { UpdateDetailedSyllabusComponent } from './scientific-and-methodological-support/disciplines/detailed-syllabus/update-detailed-syllabus/update-detailed-syllabus.component';
import { CompareClassesComponent } from './open-classes/compare-classes/compare-classes.component';
import { UpdatePlannedComponent } from './open-classes/planned-classes/update-planned/update-planned.component';

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
    DisciplinesComponent,
    CurriculumComponent,
    UpdateCurriculumComponent,
    DetailedCurriculumComponent,
    UpdateSyllabusComponent,
    DetailedSyllabusComponent,
    SyllabusFiltersComponent,
    CurriculumFiltersComponent,
    UpdateUsersComponent,
    PlannedClassesComponent,
    UsersComponent,
    KomisiiComponent,
    UpdateUsersComponent,
    DolzhnostiComponent,
    DoctypeComponent,
    GroupsComponent,
    SpecialtyComponent,
    UpdateDoctypeComponent,
    UpdateDolzhnostiComponent,
    UpdateGroupsComponent,
    UpdateKomisiiComponent,
    UpdateSpecialtyComponent,
    AddDocumentComponent,
    UpdateDetailedSyllabusComponent,
    CompareClassesComponent,
    UpdatePlannedComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    NgMultiSelectDropDownModule.forRoot(),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
