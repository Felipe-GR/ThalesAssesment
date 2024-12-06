import { Component, Input, OnInit } from '@angular/core';
import { Employee } from '../../interfaces/employee.interface';
import { voidEmployee } from '../../constants/employee.constants';

@Component({
  selector: 'app-employee-pic',
  templateUrl: './employee-pic.component.html',
  styles: [
  ]
})
export class EmployeePicComponent implements OnInit{
  @Input()
  imgSize: number = 300;
  @Input()
  public employee: Employee = voidEmployee;

  public hasLoaded: boolean = false;

  ngOnInit(): void {
    if (!this.employee.profileImage) {
      this.employee.profileImage = `https://gravatar.com/avatar/${this.employee.id}?d=robohash&s=${this.imgSize}`;
    }
  }

  public onLoad() {
    setTimeout(() => {
      this.hasLoaded = true;
    }, 1000);
  }
}
