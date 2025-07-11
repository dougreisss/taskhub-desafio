import { Component, OnInit, signal } from '@angular/core';
import { TaskServices } from '../../services/task-services';
import { TaskItemDto } from '../../models/TaskItemDto';
import { ApiResponseDto } from '../../models/ApiResponseDto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-manager',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './task-manager.html',
  styleUrl: './task-manager.scss'
})
export class TaskManager implements OnInit {

  public tasks = signal<TaskItemDto[]>([]);

  constructor(
    private taskService: TaskServices,
  ) { }

  ngOnInit(): void {

    this.taskService.getAll().subscribe((response: ApiResponseDto<TaskItemDto[]>) => {
      if (response.statusCode == 200) {
        if (response.data != null) {
          this.tasks.set(response.data as TaskItemDto[]);
        }
      }
    });

  }

  insertTask(event: KeyboardEvent): void {
    if (event.key === 'Enter') {
      // todo
    }
  }

  deleteTask(id: number) {
    this.taskService.delete(id).subscribe((resposnse: ApiResponseDto<TaskItemDto>) => {
      if (resposnse.statusCode == 200) {
        this.tasks.update(tasks => tasks.filter(task => task.id !== id));
      }
    });
  }

}
