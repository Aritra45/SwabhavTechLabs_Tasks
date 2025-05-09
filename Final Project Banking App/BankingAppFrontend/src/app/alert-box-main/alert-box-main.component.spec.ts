import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertBoxMainComponent } from './alert-box-main.component';

describe('AlertBoxMainComponent', () => {
  let component: AlertBoxMainComponent;
  let fixture: ComponentFixture<AlertBoxMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AlertBoxMainComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlertBoxMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
