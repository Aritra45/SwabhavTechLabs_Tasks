import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllAuditUseridComponent } from './get-all-audit-userid.component';

describe('GetAllAuditUseridComponent', () => {
  let component: GetAllAuditUseridComponent;
  let fixture: ComponentFixture<GetAllAuditUseridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetAllAuditUseridComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetAllAuditUseridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
