import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponseDto } from '../models/ApiResponseDto';
import { TaskItemDto } from '../models/TaskItemDto';
import { environments } from '../environments/environments';

@Injectable({
  providedIn: 'root'
})
export class TaskServices {

  private readonly apiUrl = environments.apiUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<ApiResponseDto<TaskItemDto[]>> {
    return this.http.get<ApiResponseDto<TaskItemDto[]>>(`${this.apiUrl}/task`);
  }
}
