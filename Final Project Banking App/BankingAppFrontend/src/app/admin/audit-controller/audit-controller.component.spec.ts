import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditControllerComponent } from './audit-controller.component';

describe('AuditControllerComponent', () => {
  let component: AuditControllerComponent;
  let fixture: ComponentFixture<AuditControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AuditControllerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuditControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
