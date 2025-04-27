import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeSalaryDistributionComponent } from './employee-salary-distribution.component';

describe('EmployeeSalaryDistributionComponent', () => {
  let component: EmployeeSalaryDistributionComponent;
  let fixture: ComponentFixture<EmployeeSalaryDistributionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmployeeSalaryDistributionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeSalaryDistributionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
