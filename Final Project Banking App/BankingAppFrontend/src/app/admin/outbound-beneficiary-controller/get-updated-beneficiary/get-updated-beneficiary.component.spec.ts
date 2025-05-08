import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetUpdatedBeneficiaryComponent } from './get-updated-beneficiary.component';

describe('GetUpdatedBeneficiaryComponent', () => {
  let component: GetUpdatedBeneficiaryComponent;
  let fixture: ComponentFixture<GetUpdatedBeneficiaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetUpdatedBeneficiaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetUpdatedBeneficiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
