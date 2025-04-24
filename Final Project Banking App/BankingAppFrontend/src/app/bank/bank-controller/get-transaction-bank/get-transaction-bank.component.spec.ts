import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTransactionBankComponent } from './get-transaction-bank.component';

describe('GetTransactionBankComponent', () => {
  let component: GetTransactionBankComponent;
  let fixture: ComponentFixture<GetTransactionBankComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetTransactionBankComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetTransactionBankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
