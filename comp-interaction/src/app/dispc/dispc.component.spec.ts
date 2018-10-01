import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DispcComponent } from './dispc.component';

describe('DispcComponent', () => {
  let component: DispcComponent;
  let fixture: ComponentFixture<DispcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DispcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DispcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
