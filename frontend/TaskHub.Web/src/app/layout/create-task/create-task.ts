import { ChangeDetectionStrategy, Component, inject, model, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CreateTaskItemDto } from '../../models/CreateTaskItemDto';
import { DatePipe } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { HttpStatusCode } from '@angular/common/http'
import { StatusServices } from '../../services/status-services';
import { TaskStatusDto } from '../../models/TaskStatusDto';
import { ApiResponseDto } from '../../models/ApiResponseDto';

@Component({
  selector: 'app-create-task',
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatSelectModule
  ],
  providers: [DatePipe],
  templateUrl: './create-task.html',
  styleUrl: './create-task.scss'
})

export class CreateTask implements OnInit {

  public taskStatusDto = signal<TaskStatusDto[]>([]);
  public statusSelected: number = 0;

  constructor(
    private datePipe: DatePipe,
    private statusServices: StatusServices
  ) {
  }

  ngOnInit(): void {
    this.getAllStatus();
  }

  readonly dialogRef = inject(MatDialogRef<CreateTask>);
  readonly data = inject<CreateTaskItemDto>(MAT_DIALOG_DATA);

  get formattedDate(): string | null {
    return this.datePipe.transform(this.data.dueDate, 'yyyy-MM-dd');
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  getAllStatus(): void {
    this.statusServices.getAll().subscribe((response: ApiResponseDto<TaskStatusDto[]>) => {

      if (response.statusCode == HttpStatusCode.Ok) {
        if (response.data != null) {
          this.taskStatusDto.set(response.data as TaskStatusDto[]);
        }
      }
      // todo error msg 
    });
  }

}
