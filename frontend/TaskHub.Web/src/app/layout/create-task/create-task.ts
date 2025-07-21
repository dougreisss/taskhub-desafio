import { ChangeDetectionStrategy, Component, inject, model, signal } from '@angular/core';
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
    MatDialogClose
  ],
  providers: [DatePipe],
  templateUrl: './create-task.html',
  styleUrl: './create-task.scss'
})

export class CreateTask {


  constructor(private datePipe: DatePipe) {
  }

  readonly dialogRef = inject(MatDialogRef<CreateTask>);
  readonly data = inject<CreateTaskItemDto>(MAT_DIALOG_DATA);

  get formattedDate(): string | null {
    return this.datePipe.transform(this.data.dueDate, 'yyyy-MM-dd');
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

}
