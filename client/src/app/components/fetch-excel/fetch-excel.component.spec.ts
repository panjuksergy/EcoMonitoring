import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchExcelComponent } from './fetch-excel.component';

describe('FetchExcelComponent', () => {
  let component: FetchExcelComponent;
  let fixture: ComponentFixture<FetchExcelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FetchExcelComponent]
    });
    fixture = TestBed.createComponent(FetchExcelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
