import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KlinaitsComponent } from './klinaits.component';

describe('KlinaitsComponent', () => {
  let component: KlinaitsComponent;
  let fixture: ComponentFixture<KlinaitsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KlinaitsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KlinaitsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
