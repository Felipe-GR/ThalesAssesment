import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environments } from '../../../environments/environment';
import { Employee } from '../interfaces/employee.interface';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  public baseUrl: string = environments.baseUrl;
  
  public constructor(private http: HttpClient) {}

  public getEmployees(): Observable<Employee[]>
  {
    return this.http.get<Employee[]>(`${this.baseUrl}/employee`);
  }

  public getEmployeesByName(name: string): Observable<Employee[]>
  {
    return this.http.get<Employee[]>(`${this.baseUrl}/employee/name/${name}`);
  }

  public getEmployeeById(id: number): Observable<Employee>
  {
    return this.http.get<Employee>(`${this.baseUrl}/employee/${id}`);
  }
}
