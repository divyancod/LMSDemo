import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PocListComponent } from './poc-list.component';

describe('PocListComponent', () => {
  let component: PocListComponent;
  let fixture: ComponentFixture<PocListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PocListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PocListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
