import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerifyOtpRegisterCompanyComponent } from './verify-otp-register-company.component';

describe('VerifyOtpRegisterCompanyComponent', () => {
  let component: VerifyOtpRegisterCompanyComponent;
  let fixture: ComponentFixture<VerifyOtpRegisterCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VerifyOtpRegisterCompanyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VerifyOtpRegisterCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
