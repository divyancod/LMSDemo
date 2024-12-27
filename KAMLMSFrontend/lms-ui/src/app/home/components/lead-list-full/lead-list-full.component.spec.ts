import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadListFullComponent } from './lead-list-full.component';

describe('LeadListFullComponent', () => {
  let component: LeadListFullComponent;
  let fixture: ComponentFixture<LeadListFullComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeadListFullComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LeadListFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
