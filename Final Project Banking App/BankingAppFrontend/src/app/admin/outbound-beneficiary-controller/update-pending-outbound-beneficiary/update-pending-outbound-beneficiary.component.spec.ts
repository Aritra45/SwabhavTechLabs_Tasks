import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePendingOutboundBeneficiaryComponent } from './update-pending-outbound-beneficiary.component';

describe('UpdatePendingOutboundBeneficiaryComponent', () => {
  let component: UpdatePendingOutboundBeneficiaryComponent;
  let fixture: ComponentFixture<UpdatePendingOutboundBeneficiaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdatePendingOutboundBeneficiaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdatePendingOutboundBeneficiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
