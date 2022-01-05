import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatestudentsComponent } from './updatestudents.component';

describe('UpdatestudentsComponent', () => {
  let component: UpdatestudentsComponent;
  let fixture: ComponentFixture<UpdatestudentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatestudentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatestudentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
