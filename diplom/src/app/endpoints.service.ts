import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Teacher } from './teachers/teacher.model';
import { Plan } from './scientific-and-methodological-support/uch-plans/plan.model';
import { Lesson } from './open-classes/lesson.model';
import { Disciplina } from './scientific-and-methodological-support/disciplines/disciplina.model';

@Injectable({
  providedIn: 'root'
})
export class EndpointsService {
  teacherBaseURI = 'https://localhost:44312/api/Teachers';
  PlanBaseURI = 'https://localhost:44312/api/Plan';
  PublicLessonBaseURI = 'https://localhost:44312/api/PublicLesson';
  SubjectBaseURI = 'https://localhost:44312/api/Subject';
  ConfigurationBaseURI = 'https://localhost:44312/api/Configuration';
  headers = new HttpHeaders({
    'Content-Type': 'application/json'
});
  constructor(private http: HttpClient) {}

  getTeachers() {
    return this.http.get<Teacher[]>(this.teacherBaseURI);
  }

  getTeacherById(id: number) {
    return this.http.get<Teacher>(this.teacherBaseURI +`/${id}`);
  }

  CreateOrUpdateTeacher(data: any) {
    return this.http.post(this.teacherBaseURI, data);
  }

  DeleteTeacher(id: number) {
    return this.http.delete(this.teacherBaseURI +`/${id}`);
  }

  FilterTeacher(filter: any) {
    return this.http.post(this.teacherBaseURI+'/filter', filter);
  }

  SearchTeacher(searchText: string) {
    return this.http.post(this.teacherBaseURI+"/search", JSON.stringify(searchText), {headers: this.headers});
  }

  getPlans() {
    return this.http.get<any[]>(this.PlanBaseURI);
  }

  getPlanById(id: number) {
    return this.http.get<Plan>(this.PlanBaseURI + `/${id}`);
  }

  createOrUpdatePlan(data: any) {
    return this.http.post(this.PlanBaseURI, data);
  }

  getLessons() {
    return this.http.get<Lesson[]>(this.PublicLessonBaseURI);
  }

  getLessonById(id: number) {
    return this.http.get<Lesson>(this.PublicLessonBaseURI
    + `/${id}`);
  }

  FilterPublicLesson(filter: any) {
    return this.http.post(this.PublicLessonBaseURI,filter);
  }

  SearchPublicLesson(searchText: string) {
    return this.http.post(this.PublicLessonBaseURI +"/search", JSON.stringify(searchText), {headers: this.headers});
  }

  getSubjects() {
    return this.http.get<Disciplina[]>(this.SubjectBaseURI
    );
  }

  getSubjectById(id: number) {
    return this.http.get<Disciplina>(this.SubjectBaseURI
    + `/${id}`);
  }

  FilterSubject(filter: any) {
    return this.http.post(this.SubjectBaseURI,filter);
  }

  SearchSubject(searchText: string) {
    return this.http.post(this.SubjectBaseURI+ "/search", JSON.stringify(searchText), {headers: this.headers});
  }

  getCK() {
    return this.http.get<any[]>(this.ConfigurationBaseURI+ "/ck");
  }

  createCK(ck) {
    return this.http.post<any[]>(this.ConfigurationBaseURI+ "/ck", ck);
  }

  getGroups() {
    return this.http.get<any[]>("/api/Configuration/group");
  }

  deleteCK(id) {
    return this.http.delete(this.ConfigurationBaseURI+ `/ck/${id}`);
  }

  searchCK(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI+ "/ck/search", JSON.stringify(searchText), {headers: this.headers});
  }
  createPosition(position) {
    return this.http.post<any[]>(this.ConfigurationBaseURI+ "/position", position);
  }

  getPosition() {
    return this.http.get<any[]>(this.ConfigurationBaseURI+ "/position");
  }

  deleteposition(id) {
    return this.http.delete(this.ConfigurationBaseURI+ `/position/${id}`);
  }

  SearchPosition(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI+ "/position" + "/search", JSON.stringify(searchText), {headers: this.headers});
  }
  getPositionById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI+ `/position/${id}`);
  }


}

