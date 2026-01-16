import { Component, Injector, OnInit, ChangeDetectorRef, output, EventEmitter } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormsModule } from '@angular/forms';
import { AbpModalHeaderComponent } from '../../../shared/components/modal/abp-modal-header.component';
import { AbpValidationSummaryComponent } from '../../../shared/components/validation/abp-validation.summary.component';
import { AbpModalFooterComponent } from '../../../shared/components/modal/abp-modal-footer.component';
import { LocalizePipe } from '../../../shared/pipes/localize.pipe';
import { AppComponentBase } from '../../../shared/app-component-base';
import { CreateStudentDto, StudentDto, StudentServiceProxy } from '../../../shared/service-proxies/service-proxies';


@Component({
  templateUrl: 'create.component.html',
  standalone: true,
  imports: [
    FormsModule,
    AbpModalHeaderComponent,
    AbpValidationSummaryComponent,
    AbpModalFooterComponent,
    LocalizePipe,
  ],
})
export class CreateStudentDialogComponent
  extends AppComponentBase
  implements OnInit {

  saving = false;

  student: StudentDto = new StudentDto();

  onSave = output<EventEmitter<any>>();

  constructor(
    injector: Injector,
    private _studentService: StudentServiceProxy,
    public bsModalRef: BsModalRef,
    private cd: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    // nothing to load on create
  }

  save(): void {
    this.saving = true;

    const input = new CreateStudentDto();
    input.init(this.student);

    this._studentService.create(input).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit(null);
      },
      () => {
        this.saving = false;
        this.cd.detectChanges();
      }
    );
  }
}
