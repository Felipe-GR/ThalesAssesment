import { Component } from '@angular/core';
import { voidEmployee } from '../../constants/employee.constants';
import { Employee } from '../../interfaces/employee.interface';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';

@Component({
  templateUrl: './employee-detail-page.component.html',
  styles: [
  ]
})
export class EmployeeDetailPageComponent {

  private employeeId: number = 0;
  public employee: Employee = voidEmployee;

  constructor(private route: ActivatedRoute,
            private _employeeService: EmployeeService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.employeeId = +params['id'];
      this.getEmployeeDetails();
    });
  }

  private getEmployeeDetails(){
    this._employeeService.getEmployeeById(this.employeeId).subscribe(
      resp => {
        this.employee = resp;
      }
    );
  }
}
