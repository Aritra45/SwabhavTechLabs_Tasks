import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllAuditDateComponent } from './get-all-audit-date.component';

describe('GetAllAuditDateComponent', () => {
  let component: GetAllAuditDateComponent;
  let fixture: ComponentFixture<GetAllAuditDateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetAllAuditDateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetAllAuditDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
