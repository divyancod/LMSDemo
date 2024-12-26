import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyCallCardComponent } from './modify-call-card.component';

describe('ModifyCallCardComponent', () => {
  let component: ModifyCallCardComponent;
  let fixture: ComponentFixture<ModifyCallCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModifyCallCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModifyCallCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
