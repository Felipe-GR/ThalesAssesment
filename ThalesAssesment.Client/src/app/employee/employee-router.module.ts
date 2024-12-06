import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeePageComponent } from './pages/employee.page/employee-page.component';
import { EmployeeDetailPageComponent } from './pages/employee-detail.page/employee-detail-page.component';

const routes: Routes = [
  {
    path: 'employee-details/:id',
    component: EmployeeDetailPageComponent
  },
  {
    path: 'employees-list',
    component: EmployeePageComponent
  },
  {
    path:'**',
    redirectTo: 'employees-list'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }

