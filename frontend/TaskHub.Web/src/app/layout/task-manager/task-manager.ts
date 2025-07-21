import { Component, OnInit, signal, inject, model } from '@angular/core';
import { TaskServices } from '../../services/task-services';
import { TaskItemDto } from '../../models/TaskItemDto';
import { ApiResponseDto } from '../../models/ApiResponseDto';
import { CommonModule } from '@angular/common';
import { CreateTask } from '../create-task/create-task';
import { MatDialog } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { CreateTaskItemDto } from '../../models/CreateTaskItemDto';

@Component({
  selector: 'app-task-manager',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './task-manager.html',
  styleUrl: './task-manager.scss'
})
export class TaskManager implements OnInit {

  readonly dialog = inject(MatDialog);

  public taskItemDto = signal<TaskItemDto[]>([]);

  public createTaskItemDto = signal<CreateTaskItemDto>({ title: '', description: '', statusId: 0, dueDate: new Date() });

  readonly titleInput = model('')

  constructor(
    private taskService: TaskServices,
  ) { }

  ngOnInit(): void {

    this.taskService.getAll().subscribe((response: ApiResponseDto<TaskItemDto[]>) => {
      if (response.statusCode == 200) {
        if (response.data != null) {
          this.taskItemDto.set(response.data as TaskItemDto[]);
        }
      }
    });

  }

  insertTask(event: KeyboardEvent): void {
    if (event.key === 'Enter') {
      if (this.titleInput() != "") {
        this.openDialog();
      }
    }
  }

  deleteTask(id: number) {
    this.taskService.delete(id).subscribe((resposnse: ApiResponseDto<TaskItemDto>) => {
      if (resposnse.statusCode == 200) {
        this.taskItemDto.update(tasksItemDto => tasksItemDto.filter(task => task.id !== id));
      }
    });
  }

  createTask() {
    // todo
  }

  updateTask() {
    // todo
  }

  openDialog(): void {

    this.createTaskItemDto().title = this.titleInput();

    const dialogRef = this.dialog.open(CreateTask, {
      data: this.createTaskItemDto(),
      width: '2000px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        console.log(result);
      }
    });
  }

}
