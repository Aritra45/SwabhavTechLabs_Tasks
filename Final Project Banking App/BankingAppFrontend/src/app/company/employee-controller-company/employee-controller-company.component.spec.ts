import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeControllerCompanyComponent } from './employee-controller-company.component';

describe('EmployeeControllerCompanyComponent', () => {
  let component: EmployeeControllerCompanyComponent;
  let fixture: ComponentFixture<EmployeeControllerCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmployeeControllerCompanyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeControllerCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
