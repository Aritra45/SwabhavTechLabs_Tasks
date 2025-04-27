import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateEmployeeSalaryDisburesementComponent } from './update-employee-salary-disburesement.component';

describe('UpdateEmployeeSalaryDisburesementComponent', () => {
  let component: UpdateEmployeeSalaryDisburesementComponent;
  let fixture: ComponentFixture<UpdateEmployeeSalaryDisburesementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateEmployeeSalaryDisburesementComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateEmployeeSalaryDisburesementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
