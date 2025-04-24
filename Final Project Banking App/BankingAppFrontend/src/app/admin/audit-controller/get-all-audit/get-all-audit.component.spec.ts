import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllAuditComponent } from './get-all-audit.component';

describe('GetAllAuditComponent', () => {
  let component: GetAllAuditComponent;
  let fixture: ComponentFixture<GetAllAuditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetAllAuditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetAllAuditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
