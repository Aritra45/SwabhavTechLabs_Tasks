import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInboundbeneficiaryComponent } from './add-inboundbeneficiary.component';

describe('AddInboundbeneficiaryComponent', () => {
  let component: AddInboundbeneficiaryComponent;
  let fixture: ComponentFixture<AddInboundbeneficiaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddInboundbeneficiaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddInboundbeneficiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
