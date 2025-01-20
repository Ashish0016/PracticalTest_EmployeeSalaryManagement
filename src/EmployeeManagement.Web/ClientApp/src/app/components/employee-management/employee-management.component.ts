import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditEmployeeComponent } from '../add-edit-employee/add-edit-employee.component';
import { EmployeeGridComponent } from '../employee-grid/employee-grid.component';

@Component({
  selector: 'app-employee-management',
  standalone: true,
  imports: [CommonModule, AddEditEmployeeComponent, EmployeeGridComponent],
  templateUrl: './employee-management.component.html',
  styleUrls: ['./employee-management.component.scss']
})
export class EmployeeManagementComponent implements OnInit {

  @ViewChild('employeeGrid') employeeGrid!: EmployeeGridComponent;

  constructor() { }

  ngOnInit(): void {
  }

  onAddOrUpdateEmployee() {
    this.employeeGrid.getEmployeeData();
  }
}
