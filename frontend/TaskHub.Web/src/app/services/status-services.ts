import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environments } from '../environments/environments';
import { TaskStatusDto } from '../models/TaskStatusDto';
import { ApiResponseDto } from '../models/ApiResponseDto';

@Injectable({
  providedIn: 'root'
})
export class StatusServices {

  private readonly apiUrl = environments.apiUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ApiResponseDto<TaskStatusDto[]>> {
    return this.http.get<ApiResponseDto<TaskStatusDto[]>>(`${this.apiUrl}/taskstatus`);
  }

  getById(id: number): Observable<ApiResponseDto<TaskStatusDto>> {
    return this.http.get<ApiResponseDto<TaskStatusDto>>(`${this.apiUrl}/taskstatus/${id}`);
  }

  create(taskStatus: TaskStatusDto) {
    return this.http.post(`${this.apiUrl}/taskstatus`, taskStatus);
  }

  update(taskStatus: TaskStatusDto) {
    return this.http.put(`${this.apiUrl}/taskstatus`, taskStatus);
  }

  delete(id: number): Observable<ApiResponseDto<TaskStatusDto>> {
    return this.http.delete<ApiResponseDto<TaskStatusDto>>(`${this.apiUrl}/taskstatus/${id}`);
  }
}
