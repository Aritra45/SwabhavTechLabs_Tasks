import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetUpdatedSalaryComponent } from './get-updated-salary.component';

describe('GetUpdatedSalaryComponent', () => {
  let component: GetUpdatedSalaryComponent;
  let fixture: ComponentFixture<GetUpdatedSalaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetUpdatedSalaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetUpdatedSalaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
