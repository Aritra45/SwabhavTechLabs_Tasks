import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionControllerComponent } from './transaction-controller.component';

describe('TransactionControllerComponent', () => {
  let component: TransactionControllerComponent;
  let fixture: ComponentFixture<TransactionControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TransactionControllerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
