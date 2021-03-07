import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CliInteractionCardComponent } from './cli-interaction-card.component';

describe('CliInteractionCardComponent', () => {
  let component: CliInteractionCardComponent;
  let fixture: ComponentFixture<CliInteractionCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CliInteractionCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CliInteractionCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
