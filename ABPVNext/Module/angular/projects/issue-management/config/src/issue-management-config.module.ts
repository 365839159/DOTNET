import { ModuleWithProviders, NgModule } from '@angular/core';
import { ISSUE_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class IssueManagementConfigModule {
  static forRoot(): ModuleWithProviders<IssueManagementConfigModule> {
    return {
      ngModule: IssueManagementConfigModule,
      providers: [ISSUE_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
