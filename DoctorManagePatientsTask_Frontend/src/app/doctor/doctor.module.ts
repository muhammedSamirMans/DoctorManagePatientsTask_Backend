import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorRoutingModule } from './doctor-routing.module';
import { DoctorComponent } from './doctor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SubmitComponent } from './components/submit/submit.component';
import { ViewComponent } from './components/view/view.component';
import { EditComponent } from './components/edit/edit.component';
import { DoctorsComponent } from './components/doctors/doctors.component';


@NgModule({
  declarations: [
    DoctorComponent,
    SubmitComponent,
    ViewComponent,
    EditComponent,
    DoctorsComponent
  ],
  imports: [
    CommonModule,
    DoctorRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class DoctorModule { }
