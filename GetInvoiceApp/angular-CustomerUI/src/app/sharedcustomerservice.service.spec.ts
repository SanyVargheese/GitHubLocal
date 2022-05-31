import { TestBed } from '@angular/core/testing';

import { SharedcustomerserviceService } from './sharedcustomerservice.service';

describe('SharedcustomerserviceService', () => {
  let service: SharedcustomerserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedcustomerserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
