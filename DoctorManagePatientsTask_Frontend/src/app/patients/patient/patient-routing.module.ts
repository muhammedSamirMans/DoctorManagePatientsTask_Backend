import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewComponent } from 'src/app/patients/patient/view/view/view.component'; 
import { SubmitComponent } from 'src/app/patients/patient/submit/submit.component'; 
import { EditComponent } from 'src/app/patients/patient/edit/edit.component'; 
const routes: Routes = [
  { path: 'patient/:patientId/view', component: ViewComponent },
  { path: 'patient/create', component: SubmitComponent },
  { path: 'patient/:patientId/edit', component: EditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientRoutingModule { }
