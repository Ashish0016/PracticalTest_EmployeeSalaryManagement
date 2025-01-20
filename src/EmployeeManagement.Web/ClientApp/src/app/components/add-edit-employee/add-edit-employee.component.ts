import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-add-edit-employee',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, MatFormFieldModule, MatIconModule, MatInputModule, FlexLayoutModule, MatButtonModule,
    MatDatepickerModule, MatNativeDateModule, MatSelectModule, MatOptionModule
  ],
  templateUrl: './add-edit-employee.component.html',
  styleUrls: ['./add-edit-employee.component.scss']
})
export class AddEditEmployeeComponent implements OnInit {

  @Output() addOrUpdateEmployeeValue = new EventEmitter<any>();

  private apiBaseUrl = environment.apiBaseUrl;
  public maxDate = new Date();
  public gender: GenderType[] = Gender;

  public employeeForm!: FormGroup;

  constructor(private http: HttpClient,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.employeeForm = this.formBuilder.group({
      employeeCode: [null, [Validators.required, Validators.pattern(/^\d+$/)]],
      employeeName: [null, [Validators.required]],
      dateOfBirth: [null, [Validators.required]],
      gender: [null, [Validators.required]],
      departMent: [null],
      designation: [null],
      basicSalary: [null, [Validators.required, Validators.pattern(/^\d+$/)]]
    });
  }

  AddOrUpdateEmployee() {
    const httpRequestBody = this.employeeForm.getRawValue();
    this.http.post(`${this.apiBaseUrl}/api/employee/addOrUpdateEmployee`, httpRequestBody)
      .subscribe((res) => {
        this.resetForm();
        this.addOrUpdateEmployeeValue.emit();
      });
  }

  resetForm() {
    this.employeeForm.reset();
    Object.keys(this.employeeForm.controls).forEach((key) => {
      const control = this.employeeForm.get(key);
      control?.setErrors(null);
      control?.markAsPristine();
      control?.markAsUntouched();
    });
  }
}

export enum GenderConstants {
  Male = 1,
  Female = 2,
  Other = 3
}

export interface GenderType {
  id: number,
  name: string
}

export const Gender: GenderType[] = [
  {
    id: GenderConstants.Male,
    name: 'Male'
  },
  {
    id: GenderConstants.Female,
    name: 'Female'
  }
]