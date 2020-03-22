import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KomisiiComponent } from './komisii.component';

describe('KomisiiComponent', () => {
  let component: KomisiiComponent;
  let fixture: ComponentFixture<KomisiiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KomisiiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KomisiiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
