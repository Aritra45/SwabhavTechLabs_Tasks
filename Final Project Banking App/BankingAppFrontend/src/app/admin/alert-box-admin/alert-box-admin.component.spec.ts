import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertBoxAdminComponent } from './alert-box-admin.component';

describe('AlertBoxAdminComponent', () => {
  let component: AlertBoxAdminComponent;
  let fixture: ComponentFixture<AlertBoxAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AlertBoxAdminComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlertBoxAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
