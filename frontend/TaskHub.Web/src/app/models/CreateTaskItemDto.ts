export interface CreateTaskItemDto {
    title: string;
    description: string;
    statusId: number;
    dueDate: Date;
}