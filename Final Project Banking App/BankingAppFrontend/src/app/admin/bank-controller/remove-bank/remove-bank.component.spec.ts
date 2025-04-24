import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveBankComponent } from './remove-bank.component';

describe('RemoveBankComponent', () => {
  let component: RemoveBankComponent;
  let fixture: ComponentFixture<RemoveBankComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RemoveBankComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemoveBankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
