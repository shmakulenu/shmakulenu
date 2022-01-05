import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CredistimplementationComponent } from './credistimplementation.component';

describe('CredistimplementationComponent', () => {
  let component: CredistimplementationComponent;
  let fixture: ComponentFixture<CredistimplementationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CredistimplementationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CredistimplementationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
