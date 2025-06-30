import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskManager } from './task-manager';

describe('TaskManager', () => {
  let component: TaskManager;
  let fixture: ComponentFixture<TaskManager>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TaskManager]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TaskManager);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
