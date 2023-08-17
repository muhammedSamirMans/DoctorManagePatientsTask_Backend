import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { EditNotepadComponent } from './home/edit-notepad/edit-notepad.component';
 import { PatientComponent } from './patients/patient/patient.component';
import { HomeComponent } from './home/home.component';
import { ViewComponent } from 'src/app/patients/patient/view/view/view.component'; 
import { SubmitComponent } from 'src/app/patients/patient/submit/submit.component'; 
import { EditComponent } from 'src/app/patients/patient/edit/edit.component'; 
const routes: Routes = [
  {
    path:'',
    component:HomeComponent
  },
  {
    path:'patients',
    component:PatientComponent
  },
  {
    path:'patient/:patientId/view',
    component:ViewComponent
  },
  {
    path:'patient/create',
    component:SubmitComponent
  },
  {
    path:'patient/:patientId/edit',
    component:EditComponent
  },
  { path: 'doctor', loadChildren: () => import('./doctor/doctor.module').then(m => m.DoctorModule) },
  { path: 'patient', loadChildren: () => import('./patients/patient/patient.module').then(m => m.PatientModule) },

  // {
  //   path:'edit-note',
  //   component:EditNotepadComponent
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
