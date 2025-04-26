import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOutboundbeneficiaryComponent } from './add-outboundbeneficiary.component';

describe('AddOutboundbeneficiaryComponent', () => {
  let component: AddOutboundbeneficiaryComponent;
  let fixture: ComponentFixture<AddOutboundbeneficiaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddOutboundbeneficiaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddOutboundbeneficiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
