import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styles: [
  ]
})
export class MenuComponent implements OnInit{
  public items: MenuItem[] = [];
  ngOnInit(): void {
    this.items = [
      {
        label: 'All Employees',
        icon: 'pi pi-users',
        routerLink: 'employees-list'
      }
    ];
  }
}
