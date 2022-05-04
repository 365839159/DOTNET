import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { IssueManagementComponent } from './components/issue-management.component';
import { IssueManagementRoutingModule } from './issue-management-routing.module';

@NgModule({
  declarations: [IssueManagementComponent],
  imports: [CoreModule, ThemeSharedModule, IssueManagementRoutingModule],
  exports: [IssueManagementComponent],
})
export class IssueManagementModule {
  static forChild(): ModuleWithProviders<IssueManagementModule> {
    return {
      ngModule: IssueManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<IssueManagementModule> {
    return new LazyModuleFactory(IssueManagementModule.forChild());
  }
}
