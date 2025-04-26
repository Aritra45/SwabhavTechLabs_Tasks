import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InboundbeneficiaryControllerComponent } from './inboundbeneficiary-controller.component';

describe('InboundbeneficiaryControllerComponent', () => {
  let component: InboundbeneficiaryControllerComponent;
  let fixture: ComponentFixture<InboundbeneficiaryControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InboundbeneficiaryControllerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InboundbeneficiaryControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
