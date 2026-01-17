import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from 'primeng/api';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { CreateEmployeeDialogComponent } from './create/create.component';
import { EditEmployeeDialogComponent } from './edit/edit.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    EmployeeRoutingModule,

    // standalone components
    EmployeeComponent,
    CreateEmployeeDialogComponent,
    EditEmployeeDialogComponent
  ],
})
export class EmployeeModule {}
