import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TwowayCompComponent } from './twoway-comp.component';

describe('TwowayCompComponent', () => {
  let component: TwowayCompComponent;
  let fixture: ComponentFixture<TwowayCompComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TwowayCompComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TwowayCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
