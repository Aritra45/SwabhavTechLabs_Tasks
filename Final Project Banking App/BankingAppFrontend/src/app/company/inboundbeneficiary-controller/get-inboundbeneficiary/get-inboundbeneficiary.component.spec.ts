import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetInboundbeneficiaryComponent } from './get-inboundbeneficiary.component';

describe('GetInboundbeneficiaryComponent', () => {
  let component: GetInboundbeneficiaryComponent;
  let fixture: ComponentFixture<GetInboundbeneficiaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetInboundbeneficiaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetInboundbeneficiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
