import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IStudentViewModel } from '../models/IStudentViewModel';

const API_URL = 'https://localhost:5001';

@Injectable()
export class StudentService {

  constructor(private http: HttpClient) { }

  getStudents(): Observable<any> {
    return this.http.get(`${API_URL}/api/Student`);
  }

  addStudent(studentViewModel: IStudentViewModel): any {
    return this.http.post<IStudentViewModel>(`${API_URL}/api/Student`, studentViewModel)
  }
}
