import { Component, Injector, ChangeDetectorRef, ViewChild } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService } from 'ngx-bootstrap/modal';

import { Table, TableModule } from 'primeng/table';
import { LazyLoadEvent, PrimeTemplate } from 'primeng/api';
import { Paginator, PaginatorModule } from 'primeng/paginator';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';

import { appModuleAnimation } from '../../shared/animations/routerTransition';
import { PagedListingComponentBase } from '../../shared/paged-listing-component-base';
import { LocalizePipe } from '../../shared/pipes/localize.pipe';

import {
  EmployeeDto,
  EmployeeServiceProxy
} from '../../shared/service-proxies/service-proxies';

import { CreateEmployeeDialogComponent } from './create/create.component';
import { EditEmployeeDialogComponent } from './edit/edit.component';

@Component({
  templateUrl: './employee.component.html',
  animations: [appModuleAnimation()],
  standalone: true,
  imports: [
    FormsModule,
    TableModule,
    PrimeTemplate,
    NgIf,
    PaginatorModule,
    LocalizePipe
  ],
})
export class EmployeeComponent extends PagedListingComponentBase<EmployeeDto> {

  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;

  employees: EmployeeDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _employeeService: EmployeeServiceProxy,
    private _modalService: BsModalService,
    cd: ChangeDetectorRef
  ) {
    super(injector, cd);
  }

  list(event?: LazyLoadEvent): void {
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      if (this.primengTableHelper.records?.length) {
        return;
      }
    }

    this.primengTableHelper.showLoadingIndicator();

    this._employeeService
     this._employeeService
  .getAll()
  .subscribe(result => {
    this.primengTableHelper.records = result;
    this.primengTableHelper.totalRecordsCount = result.length;
    this.cd.detectChanges();
  });
     
  }

  createEmployee(): void {
    const modalRef = this._modalService.show(CreateEmployeeDialogComponent, {
      class: 'modal-lg',
    });

    modalRef.content.onSave.subscribe(() => this.refresh());
  }

  editEmployee(employee: EmployeeDto): void {
    const modalRef = this._modalService.show(EditEmployeeDialogComponent, {
      class: 'modal-lg',
      initialState: {
        id: employee.id,
      },
    });

    modalRef.content.onSave.subscribe(() => this.refresh());
  }

  delete(employee: EmployeeDto): void {
    abp.message.confirm(
      this.l('EmployeeDeleteWarningMessage', employee.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._employeeService.delete(employee.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }
}
