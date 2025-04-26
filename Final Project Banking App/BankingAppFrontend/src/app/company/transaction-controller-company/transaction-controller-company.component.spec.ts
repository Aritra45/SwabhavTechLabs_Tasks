import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionControllerCompanyComponent } from './transaction-controller-company.component';

describe('TransactionControllerCompanyComponent', () => {
  let component: TransactionControllerCompanyComponent;
  let fixture: ComponentFixture<TransactionControllerCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TransactionControllerCompanyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionControllerCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
