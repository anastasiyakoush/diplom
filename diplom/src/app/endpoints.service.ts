import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Teacher } from './teachers/teacher.model';
import { Plan } from './scientific-and-methodological-support/uch-plans/plan.model';
import { Lesson } from './open-classes/lesson.model';
import { Disciplina } from './scientific-and-methodological-support/disciplines/disciplina.model';
import { Observable } from 'rxjs';

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
header = new HttpHeaders({
  'Content-Type': 'application/json',
  'responseType': 'application/octet-stream',
 'observe':'response'
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

  createOrUpdateLesson(data: any) {
    return this.http.post(this.PublicLessonBaseURI, data);
  }
  getLessons() {
    return this.http.get<Lesson[]>(this.PublicLessonBaseURI);
  }

  getCompareLessons() {
    return this.http.get<any[]>(this.PublicLessonBaseURI+'/compare');
  }

  getLessonById(id: number) {
    return this.http.get<Lesson>(this.PublicLessonBaseURI
    + `/${id}`);
  }
  createOrUpdatePlannedLesson(data: any) {
    return this.http.post(this.PublicLessonBaseURI +'/planning', data);
  }
  getPlannedLessons() {
    return this.http.get<any[]>(this.PublicLessonBaseURI+'/planning');
  }

  getPlannedLessonById(id: number) {
    return this.http.get<any>(this.PublicLessonBaseURI+'/planning'
    + `/${id}`);
  }

  FilterPublicLesson(filter: any) {
    return this.http.post(this.PublicLessonBaseURI,filter);
  }

  SearchPublicLesson(searchText: string) {
    return this.http.post(this.PublicLessonBaseURI +"/search", JSON.stringify(searchText), {headers: this.headers});
  }
  SearchPlannedPublicLesson(searchText: string) {
    return this.http.post(this.PublicLessonBaseURI +'/planning'+"/search", JSON.stringify(searchText), {headers: this.headers});
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
    return this.http.post(this.SubjectBaseURI+'/filter',filter);
  }

  CreateorUpdateSubject(data: any) {
    return this.http.post(this.SubjectBaseURI,data);
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
  getDoctype() {
    return this.http.get<any[]>(this.ConfigurationBaseURI+ "/doctype");
  }
  createDoctype(position) {
    return this.http.post<any[]>(this.ConfigurationBaseURI+ "/doctype", position);
  }
  deleteDoctype(id) {
    return this.http.delete(this.ConfigurationBaseURI+ `/doctype/${id}`);
  }
  getDoctypeById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI+ `/doctype/${id}`);
  }

  SearchDoctype(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI+ "/doctype" + "/search", JSON.stringify(searchText), {headers: this.headers});
  }
  createGroup(position) {
    return this.http.post<any[]>(this.ConfigurationBaseURI+ "/group", position);
  }

  getGroup() {
    return this.http.get<any[]>(this.ConfigurationBaseURI+ "/group");
  }

  deleteGroup(id) {
    return this.http.delete(this.ConfigurationBaseURI+ `/group/${id}`);
  }

  SearchGroup(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI+ "/group" + "/search", JSON.stringify(searchText), {headers: this.headers});
  }

  getGroupById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI+ `/group/${id}`);
  }

  createSpec(position) {
    return this.http.post<any[]>(this.ConfigurationBaseURI+ "/specialnost", position);
  }

  getSpecialnost() {
    return this.http.get<any[]>(this.ConfigurationBaseURI+ "/specialnost");
  }

  deleteSpec(id) {
    return this.http.delete(this.ConfigurationBaseURI+ `/specialnost/${id}`);
  }

  SearchSpec(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI+ "/specialnost" + "/search", JSON.stringify(searchText), {headers: this.headers});
  }

  getSpecById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI+ `/specialnost/${id}`);
  }

  documentDownload(link: string) {

    return  this.http.post(  'https://localhost:44312/api/Document/download',JSON.stringify(link),{headers: this.headers, responseType: 'blob' as 'json'}).subscribe(
      (response: any) =>{
          let dataType = response.type;
          let binaryData = [];
          binaryData.push(response);
          let downloadLink = document.createElement('a');
          downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, {type: dataType}));
          if (link)
              downloadLink.setAttribute('download', link);
          document.body.appendChild(downloadLink);
          downloadLink.click();
      });
  }
}

