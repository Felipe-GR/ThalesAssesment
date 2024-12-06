import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Employee } from '../../interfaces/employee.interface';
import { voidEmployee } from '../../constants/employee.constants';

@Component({
  selector: 'app-employee-table',
  templateUrl: './employee-table.component.html',
  styles: []
})
export class EmployeeTableComponent {

  @Input()
  public employees: Employee[] = [];
  @Output()
  itemSelected: EventEmitter<Employee> = new EventEmitter();
  public selectedItem:Employee = voidEmployee;

  public selectionChanged(event: any) : void {
    this.itemSelected.emit(this.selectedItem);
  }
}
