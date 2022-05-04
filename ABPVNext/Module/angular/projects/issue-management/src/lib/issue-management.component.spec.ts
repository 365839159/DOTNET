import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { IssueManagementComponent } from './issue-management.component';

describe('IssueManagementComponent', () => {
  let component: IssueManagementComponent;
  let fixture: ComponentFixture<IssueManagementComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ IssueManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IssueManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
