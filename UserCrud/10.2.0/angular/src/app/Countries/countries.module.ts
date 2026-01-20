import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';





import { CountryRoutingModule } from './countries-routing.module';

@NgModule({
  declarations: [
    CountryComponent 
  ],
  imports: [
    CommonModule,
    FormsModule,
    ModalModule.forChild(),
    CountryRoutingModule
  ]
})
export class CountryModule {}

