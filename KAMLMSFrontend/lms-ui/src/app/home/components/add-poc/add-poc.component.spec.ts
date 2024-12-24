import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPocComponent } from './add-poc.component';

describe('AddPocComponent', () => {
  let component: AddPocComponent;
  let fixture: ComponentFixture<AddPocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPocComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
