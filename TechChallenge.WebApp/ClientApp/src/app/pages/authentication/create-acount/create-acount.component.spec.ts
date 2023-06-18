import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAcountComponent } from './create-acount.component';

describe('CreateAcountComponent', () => {
  let component: CreateAcountComponent;
  let fixture: ComponentFixture<CreateAcountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateAcountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateAcountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
