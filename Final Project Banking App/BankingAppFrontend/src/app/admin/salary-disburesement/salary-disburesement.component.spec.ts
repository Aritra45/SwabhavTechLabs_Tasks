import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaryDisburesementComponent } from './salary-disburesement.component';

describe('SalaryDisburesementComponent', () => {
  let component: SalaryDisburesementComponent;
  let fixture: ComponentFixture<SalaryDisburesementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SalaryDisburesementComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SalaryDisburesementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
