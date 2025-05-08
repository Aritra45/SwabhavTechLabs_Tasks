import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllUpdatedTransactionComponent } from './get-all-updated-transaction.component';

describe('GetAllUpdatedTransactionComponent', () => {
  let component: GetAllUpdatedTransactionComponent;
  let fixture: ComponentFixture<GetAllUpdatedTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetAllUpdatedTransactionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetAllUpdatedTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
