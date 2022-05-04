import { Component, OnInit } from '@angular/core';
import { IssueManagementService } from '../services/issue-management.service';

@Component({
  selector: 'lib-issue-management',
  template: ` <p>issue-management works!</p> `,
  styles: [],
})
export class IssueManagementComponent implements OnInit {
  constructor(private service: IssueManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
