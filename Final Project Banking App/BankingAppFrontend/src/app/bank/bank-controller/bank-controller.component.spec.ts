import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BankControllerComponent } from './bank-controller.component';

describe('BankControllerComponent', () => {
  let component: BankControllerComponent;
  let fixture: ComponentFixture<BankControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BankControllerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BankControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
