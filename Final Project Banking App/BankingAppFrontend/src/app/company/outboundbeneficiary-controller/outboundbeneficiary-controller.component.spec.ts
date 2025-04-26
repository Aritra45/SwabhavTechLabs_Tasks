import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OutboundbeneficiaryControllerComponent } from './outboundbeneficiary-controller.component';

describe('OutboundbeneficiaryControllerComponent', () => {
  let component: OutboundbeneficiaryControllerComponent;
  let fixture: ComponentFixture<OutboundbeneficiaryControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OutboundbeneficiaryControllerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OutboundbeneficiaryControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
