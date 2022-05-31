import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetDeleteCustomerComponent } from './get-delete-customer.component';

describe('GetDeleteCustomerComponent', () => {
  let component: GetDeleteCustomerComponent;
  let fixture: ComponentFixture<GetDeleteCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetDeleteCustomerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetDeleteCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
