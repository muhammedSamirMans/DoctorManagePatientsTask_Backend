import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PatientRoutingModule } from './patient-routing.module';
import { EditComponent } from './edit/edit.component';


@NgModule({
  declarations: [
    EditComponent
  ],
  imports: [
    CommonModule, 
    ReactiveFormsModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class PatientModule { }
