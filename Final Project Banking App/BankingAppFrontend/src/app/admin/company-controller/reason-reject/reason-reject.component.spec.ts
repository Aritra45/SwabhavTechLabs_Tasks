import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReasonRejectComponent } from './reason-reject.component';

describe('ReasonRejectComponent', () => {
  let component: ReasonRejectComponent;
  let fixture: ComponentFixture<ReasonRejectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ReasonRejectComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReasonRejectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
