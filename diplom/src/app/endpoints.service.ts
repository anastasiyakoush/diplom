import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Teacher } from './teachers/teacher.model';
import { Plan } from './scientific-and-methodological-support/uch-plans/plan.model';
import { Lesson } from './open-classes/lesson.model';
import { disciplina } from './scientific-and-methodological-support/disciplines/disciplina.model';
import { Observable } from 'rxjs';
import { User } from './configuration/users/teacher.model';

@Injectable({
  providedIn: 'root'
})
export class EndpointsService {
  teacherBaseURI = 'https://localhost:44312/api/Teachers';
  PlanBaseURI = 'https://localhost:44312/api/Plan';
  PublicLessonBaseURI = 'https://localhost:44312/api/PublicLesson';
  SubjectBaseURI = 'https://localhost:44312/api/Subject';
  ConfigurationBaseURI = 'https://localhost:44312/api/Configuration';
  AccountBaseURI = 'https://localhost:44312/api/Account';
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'responseType': 'application/octet-stream',
     Authorization: 'Bearer ' + this.getToken(),
    'observe': 'response'
  });

  constructor(private http: HttpClient) { }
// Teachers
  getTeachers() {
    return this.http.get<any[]>(this.teacherBaseURI, {headers: this.headers});
  }

  getTeacherById(id: number) {
    return this.http.get<Teacher>(this.teacherBaseURI + `/${id}`, {headers: this.headers});
  }

  CreateOrUpdateTeacher(data: any) {
    return this.http.post(this.teacherBaseURI, data,{headers: this.headers});
  }

  DeleteTeacher(id: number) {
    return this.http.delete(this.teacherBaseURI + `/${id}`, {headers: this.headers});
  }

  FilterTeacher(filter: any) {
    return this.http.post(this.teacherBaseURI + '/filter', filter, {headers: this.headers});
  }

  SearchTeacher(searchText: string) {
    return this.http.post(this.teacherBaseURI + "/search", JSON.stringify(searchText), { headers: this.headers });
  }
// Methodological Support
  getObrPlans() {
    return this.http.get<any[]>(this.PlanBaseURI +'/obr',{headers: this.headers});
  }

  getObrPlanById(id: number) {
    return this.http.get<Plan>(this.PlanBaseURI + `/obr/${id}`, {headers: this.headers});
  }

  filterObrPlan(filter: any) {
    return this.http.post(this.PlanBaseURI + 'obr/filter', filter, {headers: this.headers});
  }

  getTypePlans() {
    return this.http.get<any[]>(this.PlanBaseURI + '/tip', {headers: this.headers});
  }

  filterTypePlan(filter: any) {
    return this.http.post(this.PlanBaseURI + '/tip/filter', filter, {headers: this.headers})
  }

  DeleteTypePlan(id: number) {
    return this.http.delete(this.PlanBaseURI + '/tip' + `/${id}`, {headers: this.headers});
  }

  getTypePlanById(id: number) {
    return this.http.get<Plan>(this.PlanBaseURI + `/tip/${id}`, {headers: this.headers});
  }

  getPlans() {
    const token = this.getToken();
    return this.http.get<any[]>(this.PlanBaseURI, {headers: this.headers});
  }

  getUchPlans() {
    const token = this.getToken();
    return this.http.get<any[]>(this.PlanBaseURI + '/uch', {headers: this.headers});
  }

  filterPlan(filter: any) {
    return this.http.post(this.PlanBaseURI + '/uch/filter', filter, {headers: this.headers})
  }

  DeletePlan(id: number) {
    return this.http.delete(this.PlanBaseURI + '/uch' + `/${id}`, {headers: this.headers});
  }

  getUchPlanById(id: number) {
    return this.http.get<Plan>(this.PlanBaseURI + '/uch' + `/${id}`, {headers: this.headers});
  }

  getPlanById(id: number) {
    return this.http.get<Plan>(this.PlanBaseURI + `/${id}`, {headers: this.headers});
  }

  createOrUpdatePlan(data: any) {
    return this.http.post(this.PlanBaseURI, data, {headers: this.headers});
  }

  getSubjects() {
    return this.http.get<any[]>(this.SubjectBaseURI, {headers: this.headers});
  }

  getSubjectById(id: number) {
    return this.http.get<disciplina>(this.SubjectBaseURI + `/${id}`, {headers: this.headers});
  }

  FilterSubject(filter: any) {
    return this.http.post(this.SubjectBaseURI + '/filter', filter, {headers: this.headers});
  }

  DeleteSubject(id: number) {
    return this.http.delete(this.SubjectBaseURI + `/${id}`, {headers: this.headers});
  }

  CreateorUpdateSubject(data: any) {
    return this.http.post(this.SubjectBaseURI, data, {headers: this.headers});
  }

  SearchSubject(searchText: string) {
    return this.http.post(this.SubjectBaseURI + "/search", JSON.stringify(searchText), { headers: this.headers });
  }
// Open Lessons
  createOrUpdateLesson(data: any) {
    return this.http.post(this.PublicLessonBaseURI, data, {headers: this.headers});
  }
  getLessons() {
    return this.http.get<Lesson[]>(this.PublicLessonBaseURI, {headers: this.headers});
  }

  getCompareLessons() {
    return this.http.get<any[]>(this.PublicLessonBaseURI + '/compare', {headers: this.headers});
  }

  getLessonById(id: number) {
    return this.http.get<Lesson>(this.PublicLessonBaseURI + `/${id}`, {headers: this.headers});
  }

  DeleteLesson(id: number) {
    return this.http.delete(this.PublicLessonBaseURI +  `/${id}`, {headers: this.headers});
  }

  createOrUpdatePlannedLesson(data: any) {
    return this.http.post(this.PublicLessonBaseURI + '/planning', data, {headers: this.headers});
  }

  getPlannedLessons() {
    return this.http.get<any[]>(this.PublicLessonBaseURI + '/planning', {headers: this.headers});
  }

  getPlannedLessonById(id: number) {
    return this.http.get<any>(this.PublicLessonBaseURI + '/planning' + `/${id}`, {headers: this.headers});
  }

  FilterPublicLesson(filter: any) {
    return this.http.post(this.PublicLessonBaseURI + '/filter', filter, {headers: this.headers});
  }

  SearchPublicLesson(searchText: string) {
    return this.http.post(this.PublicLessonBaseURI + "/search", JSON.stringify(searchText), { headers: this.headers });
  }

  SearchPlannedPublicLesson(searchText: string) {
    return this.http.post(this.PublicLessonBaseURI + '/planning' + "/search", JSON.stringify(searchText), { headers: this.headers });
  }

  DeletePlannedPublicLesson(id: number) {
    return this.http.delete(this.PublicLessonBaseURI + '/planning' + `/${id}`, {headers: this.headers});
  }
// Configuration
  getCK() {
    return this.http.get<any[]>(this.ConfigurationBaseURI + "/ck", {headers: this.headers});
  }

  createCK(ck) {
    return this.http.post<any[]>(this.ConfigurationBaseURI + "/ck", ck, {headers: this.headers});
  }

  getGroups() {
    return this.http.get<any[]>("/api/Configuration/group", {headers: this.headers});
  }

  deleteCK(id) {
    return this.http.delete(this.ConfigurationBaseURI + `/ck/${id}`, {headers: this.headers});
  }

  getCKById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI + `/ck/${id}`, {headers: this.headers});
  }

  searchCK(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI + "/ck/search", JSON.stringify(searchText), { headers: this.headers });
  }

  createPosition(position) {
    return this.http.post<any[]>(this.ConfigurationBaseURI + "/position", position, {headers: this.headers});
  }

  getPosition() {
    return this.http.get<any[]>(this.ConfigurationBaseURI + "/position", {headers: this.headers});
  }

  deleteposition(id) {
    return this.http.delete(this.ConfigurationBaseURI + `/position/${id}`, {headers: this.headers});
  }

  SearchPosition(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI + "/position" + "/search", JSON.stringify(searchText), { headers: this.headers });
  }

  getPositionById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI + `/position/${id}`, {headers: this.headers});
  }

  getDoctype() {
    return this.http.get<any[]>(this.ConfigurationBaseURI + "/doctype",{headers: this.headers});
  }

  createDoctype(position) {
    return this.http.post<any[]>(this.ConfigurationBaseURI + "/doctype", position, {headers: this.headers});
  }

  deleteDoctype(id) {
    return this.http.delete(this.ConfigurationBaseURI + `/doctype/${id}`, {headers: this.headers});
  }

  getDoctypeById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI + `/doctype/${id}`, {headers: this.headers});
  }

  SearchDoctype(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI + "/doctype" + "/search", JSON.stringify(searchText), { headers: this.headers });
  }

  createGroup(position) {
    return this.http.post<any[]>(this.ConfigurationBaseURI + "/group", position, {headers: this.headers});
  }

  getGroup() {
    return this.http.get<any[]>(this.ConfigurationBaseURI + "/group", {headers: this.headers});
  }

  deleteGroup(id) {
    return this.http.delete(this.ConfigurationBaseURI + `/group/${id}`, {headers: this.headers});
  }

  SearchGroup(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI + "/group" + "/search", JSON.stringify(searchText), { headers: this.headers });
  }

  getGroupById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI + `/group/${id}`, {headers: this.headers});
  }

  createSpec(position) {
    return this.http.post<any[]>(this.ConfigurationBaseURI + "/specialnost", position, {headers: this.headers});
  }

  getSpecialnost() {
    return this.http.get<any[]>(this.ConfigurationBaseURI + "/specialnost", {headers: this.headers});
  }

  deleteSpec(id) {
    return this.http.delete(this.ConfigurationBaseURI + `/specialnost/${id}`, {headers: this.headers});
  }

  SearchSpec(searchText: string) {
    return this.http.post(this.ConfigurationBaseURI + "/specialnost" + "/search", JSON.stringify(searchText), { headers: this.headers });
  }

  getSpecById(id) {
    return this.http.get<any>(this.ConfigurationBaseURI + `/specialnost/${id}`, {headers: this.headers});
  }
// Authorization
  getToken() {
    return sessionStorage.getItem('token');
  }

  getAllUsers() {
    return this.http.get<any[]>('https://localhost:44312/api/Account/all', {headers: this.headers});
  }

  getUserById(id) {
    return this.http.get<any>(this.AccountBaseURI+`/user/${id}`, {headers: this.headers});
  }

  searchUser(searchText: string) {
    return this.http.post(this.AccountBaseURI+'/search', JSON.stringify(searchText), { headers: this.headers });
  }

  CreateUser(data: User) {

    return this.http.post<User>(this.AccountBaseURI, data, { headers: this.headers });
  }

  deleteUser(id) {
    return this.http.delete(this.AccountBaseURI+`/${id}`, {headers: this.headers});
  }

  signIn(data: any) {
    return this.http.post<any>(this.AccountBaseURI+"/signin", data);
  }
//
  documentDownload(link: string) {

    return this.http.post('https://localhost:44312/api/Document/download', JSON.stringify(link), { headers: this.headers, responseType: 'blob' as 'json' }).subscribe(
      (response: any) => {
        let dataType = response.type;
        let binaryData = [];
        binaryData.push(response);
        let downloadLink = document.createElement('a');
        downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, { type: dataType }));
        if (link)
          downloadLink.setAttribute('download', link);
        document.body.appendChild(downloadLink);
        downloadLink.click();
      });
  }

  getLessonByTeacherId(id) {
    return this.http.get<any[]>('https://localhost:44312/api/PublicLesson/teacher/'
      + `${id}`, {headers: this.headers});
  }
  getDocByTeacherId(id) {
    return this.http.get<any[]>('https://localhost:44312/api/Document/author/'
      + `${id}`, {headers: this.headers});
  }

  getDocByDiscId(id) {
    return this.http.get<any[]>('https://localhost:44312/api/Document/discipline/'
      + `${id}`, {headers: this.headers});
  }

  getDocById(id) {
    return this.http.get<any[]>('https://localhost:44312/api/Document/'
      + `${id}`, {headers: this.headers});
  }

  deleteDocById(id) {
    return this.http.delete('https://localhost:44312/api/Document/'
    + `${id}`, {headers: this.headers});
  }

  CreateDocByDiscId(data) {
    return this.http.post('https://localhost:44312/api/Document', data, {headers: this.headers});
  }
}

