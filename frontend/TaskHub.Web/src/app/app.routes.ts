import { Routes } from '@angular/router';
import { TaskManager } from './layout/task-manager/task-manager';

export const routes: Routes = [
    { path: '', redirectTo: 'task', pathMatch: 'full' },
    { path: 'task',  component: TaskManager }
];
