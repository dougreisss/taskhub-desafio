import { TaskStatusDto } from "./TaskStatusDto";

export interface TaskItemDto {
    id: number;
    title: string;
    description: string;
    status: TaskStatusDto;
    createdAt: Date;
    dueDate: Date;
}