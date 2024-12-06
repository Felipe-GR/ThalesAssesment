import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeePageComponent } from './pages/employee.page/employee-page.component';
import { EmployeeDetailPageComponent } from './pages/employee-detail.page/employee-detail-page.component';
import { EmployeeRoutingModule } from './employee-router.module';
import { EmployeeTableComponent } from './components/employee-table/employee-table.component';
import { PrimeNgModule } from '../primeNg/prime-ng.module';
import { EmployeePicComponent } from './components/employee-pic/employee-pic.component';

@NgModule({
  declarations: [
    EmployeePageComponent,
    EmployeeDetailPageComponent,
    EmployeeTableComponent,
    EmployeePicComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    EmployeeRoutingModule,
    PrimeNgModule
  ],
})
export class EmployeeModule {}
