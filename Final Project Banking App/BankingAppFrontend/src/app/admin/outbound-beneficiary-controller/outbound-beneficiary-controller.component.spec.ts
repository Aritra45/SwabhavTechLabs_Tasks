import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OutboundBeneficiaryControllerComponent } from './outbound-beneficiary-controller.component';

describe('OutboundBeneficiaryControllerComponent', () => {
  let component: OutboundBeneficiaryControllerComponent;
  let fixture: ComponentFixture<OutboundBeneficiaryControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OutboundBeneficiaryControllerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OutboundBeneficiaryControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
