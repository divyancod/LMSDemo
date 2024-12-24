import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CallScheduledListComponent } from './call-scheduled-list.component';

describe('CallScheduledListComponent', () => {
  let component: CallScheduledListComponent;
  let fixture: ComponentFixture<CallScheduledListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CallScheduledListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CallScheduledListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
