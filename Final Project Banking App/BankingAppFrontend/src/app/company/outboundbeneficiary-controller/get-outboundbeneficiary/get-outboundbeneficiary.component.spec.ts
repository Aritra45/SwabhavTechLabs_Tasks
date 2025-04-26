import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetOutboundbeneficiaryComponent } from './get-outboundbeneficiary.component';

describe('GetOutboundbeneficiaryComponent', () => {
  let component: GetOutboundbeneficiaryComponent;
  let fixture: ComponentFixture<GetOutboundbeneficiaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetOutboundbeneficiaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetOutboundbeneficiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
