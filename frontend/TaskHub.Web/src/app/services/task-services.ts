import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponseDto } from '../models/ApiResponseDto';
import { TaskItemDto } from '../models/TaskItemDto';
import { environments } from '../environments/environments';
import { CreateTaskItemDto } from '../models/CreateTaskItemDto';
import { UpdateTaskItemDto } from '../models/UpdateTaskItemDto';

@Injectable({
  providedIn: 'root'
})
export class TaskServices {

  private readonly apiUrl = environments.apiUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ApiResponseDto<TaskItemDto[]>> {
    return this.http.get<ApiResponseDto<TaskItemDto[]>>(`${this.apiUrl}/task`);
  }

  getById(id: number): Observable<ApiResponseDto<TaskItemDto>> {
    return this.http.get<ApiResponseDto<TaskItemDto>>(`${this.apiUrl}/task/${id}`);
  }

  create(task: CreateTaskItemDto): Observable<ApiResponseDto<TaskItemDto>> {
    return this.http.post<ApiResponseDto<TaskItemDto>>(`${this.apiUrl}/task`, task);
  }

  update(task: UpdateTaskItemDto): Observable<ApiResponseDto<TaskItemDto>> {
    return this.http.put<ApiResponseDto<TaskItemDto>>(`${this.apiUrl}/task`, task);
  }

  delete(id: number): Observable<ApiResponseDto<TaskItemDto>> {
    return this.http.delete<ApiResponseDto<TaskItemDto>>(`${this.apiUrl}/task/${id}`);
  }
}
