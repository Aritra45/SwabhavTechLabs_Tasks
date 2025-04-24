import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetBankIdComponent } from './get-bank-id.component';

describe('GetBankIdComponent', () => {
  let component: GetBankIdComponent;
  let fixture: ComponentFixture<GetBankIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetBankIdComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetBankIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
