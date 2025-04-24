import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePendingCompaniesComponent } from './update-pending-companies.component';

describe('UpdatePendingCompaniesComponent', () => {
  let component: UpdatePendingCompaniesComponent;
  let fixture: ComponentFixture<UpdatePendingCompaniesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdatePendingCompaniesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdatePendingCompaniesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
