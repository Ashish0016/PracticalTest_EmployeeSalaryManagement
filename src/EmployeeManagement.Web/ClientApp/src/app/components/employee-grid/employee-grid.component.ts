import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { HttpClient } from '@angular/common/http';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-employee-grid',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatPaginatorModule, MatIconModule, DatePipe],
  templateUrl: './employee-grid.component.html',
  styleUrls: ['./employee-grid.component.scss']
})
export class EmployeeGridComponent implements OnInit {

  @ViewChild('paginator') paginator: MatPaginator | undefined;

  private apiBaseUrl = environment.apiBaseUrl;
  public displayedColumns: string[] = ['EmployeeCode', 'Name', 'DateOfBirth', 'Gender', 'Department', 'Designation', 'BasicSalary',
    'DearnessAllowance', 'ConveyanceAllowance', 'HouseRentAllowance', 'Action'];
  public dataSource!: MatTableDataSource<any>;
  public totalRecords: any;
  public pageSizes = [5, 10, 15];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEmployeeData();
  }

  getEmployeeData($event: any = undefined) {
    const httpRequestBody = {
      pageNumber: $event != undefined ? $event.pageIndex : 0,
      pageSize: $event != undefined ? $event.pageSize : 5
    };

    this.http.post(`${this.apiBaseUrl}/api/employee/getEmployees`, httpRequestBody)
      .subscribe((res: any) => {
        this.totalRecords = res.totalRecords;
        this.dataSource = new MatTableDataSource(res.employees);
      })
  }

  deleteEmployee(row: any) {
    this.http.delete(`${this.apiBaseUrl}/api/employee/deleteEmployee/${row.id}`)
      .subscribe((res: any) => {
        this.getEmployeeData();
      })
  }
}
