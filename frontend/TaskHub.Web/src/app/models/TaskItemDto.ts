import { TaskStatusDto } from "./TaskStatusDto";

export interface TaskItemDto {
    Id: number;
    Title: string;
    Description: string;
    Status: TaskStatusDto;
    CreatedAt: Date;
    DueDate: Date;
}