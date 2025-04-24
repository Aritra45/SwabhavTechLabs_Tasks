import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateBankPasswordComponent } from './update-bank-password.component';

describe('UpdateBankPasswordComponent', () => {
  let component: UpdateBankPasswordComponent;
  let fixture: ComponentFixture<UpdateBankPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateBankPasswordComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateBankPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
