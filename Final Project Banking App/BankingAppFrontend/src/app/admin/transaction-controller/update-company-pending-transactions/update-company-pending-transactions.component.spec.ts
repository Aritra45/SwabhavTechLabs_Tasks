import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCompanyPendingTransactionsComponent } from './update-company-pending-transactions.component';

describe('UpdateCompanyPendingTransactionsComponent', () => {
  let component: UpdateCompanyPendingTransactionsComponent;
  let fixture: ComponentFixture<UpdateCompanyPendingTransactionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateCompanyPendingTransactionsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateCompanyPendingTransactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
