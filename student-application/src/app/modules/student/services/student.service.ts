import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from "../../../../environments/environment";
import { Observable, Subject, throwError } from 'rxjs';
import { StudentModel } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})

export class StudentService {
    private path: string;
    private baseUrl: string;

    constructor(private http: HttpClient) {
        this.path = "api/Student";
        this.baseUrl = environment.apiUrl;
    }

    getStudentDetailById(id: number): Observable<StudentModel>{
        return this.http.get<StudentModel>(this.baseUrl + this.path + '/' + id);
    }

    getStudentList(): Observable<StudentModel[]>{
        return this.http.get<StudentModel[]>(this.baseUrl + this.path + '/list');
    }

    saveStudent(student: StudentModel): Observable<StudentModel>{
        return this.http.post<StudentModel>(this.baseUrl + this.path + '/create-student', student);
    }
}
