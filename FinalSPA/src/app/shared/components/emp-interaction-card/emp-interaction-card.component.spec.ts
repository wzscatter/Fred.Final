import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpInteractionCardComponent } from './emp-interaction-card.component';

describe('EmpInteractionCardComponent', () => {
  let component: EmpInteractionCardComponent;
  let fixture: ComponentFixture<EmpInteractionCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpInteractionCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmpInteractionCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
