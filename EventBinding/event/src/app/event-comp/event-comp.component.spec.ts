import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EventCompComponent } from './event-comp.component';

describe('EventCompComponent', () => {
  let component: EventCompComponent;
  let fixture: ComponentFixture<EventCompComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EventCompComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
