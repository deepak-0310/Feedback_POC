import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvideFeedbacksComponent } from './provide-feedbacks.component';

describe('ProvideFeedbacksComponent', () => {
  let component: ProvideFeedbacksComponent;
  let fixture: ComponentFixture<ProvideFeedbacksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProvideFeedbacksComponent]
    });
    fixture = TestBed.createComponent(ProvideFeedbacksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
