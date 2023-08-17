import { TestBed } from '@angular/core/testing';

import { PatientcrudserviceService } from './patientcrudservice.service';

describe('PatientcrudserviceService', () => {
  let service: PatientcrudserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PatientcrudserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
