import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/employee/services/employee.service'
import { Employee } from '../../interfaces/employee.interface';
import { voidEmployee } from '../../constants/employee.constants';
import { Router } from '@angular/router';

@Component({
  templateUrl: './employee-page.component.html',
  styles: [
  ]
})
export class EmployeePageComponent implements OnInit {

  public employees: Employee[] = [];
  public selectedItem: Employee = voidEmployee;
  public suggestions: Employee[] = [];

  public constructor(private _employeeService: EmployeeService, private router: Router) {}

  ngOnInit(): void {
    this.getEmployees();
  }

  public getEmployees() : void
  {
    this._employeeService.getEmployees().subscribe(
      resp => {
        this.employees = resp
      }
    );
  }

  public search(event: any): void {
    const name = event.query;
    this._employeeService.getEmployeesByName(name).subscribe(
      resp => {
        this.suggestions = resp;
      }
    );
  }

  public employeeSelected(event: any): void {
    if (event.id) {
      this.router.navigateByUrl(`/employees/employee-details/${event.id}`);
    }
  }

}
