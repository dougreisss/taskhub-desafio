import { TestBed } from '@angular/core/testing';

import { StatusServices } from './status-services';

describe('StatusService', () => {
  let service: StatusServices;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StatusServices);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
