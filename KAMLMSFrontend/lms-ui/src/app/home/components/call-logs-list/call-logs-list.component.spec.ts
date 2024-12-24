import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CallLogsListComponent } from './call-logs-list.component';

describe('CallLogsListComponent', () => {
  let component: CallLogsListComponent;
  let fixture: ComponentFixture<CallLogsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CallLogsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CallLogsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
