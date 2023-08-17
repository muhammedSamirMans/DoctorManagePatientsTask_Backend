import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorComponent } from './doctor.component';
import { SubmitComponent } from './components/submit/submit.component';
import { ViewComponent } from './components/view/view.component';
import { EditComponent } from './components/edit/edit.component';
import { DoctorsComponent } from './components/doctors/doctors.component';

const routes: Routes = [{ path: '', component: DoctorComponent ,children:[{
path:'',
component:DoctorsComponent
},
{
  path:':patientId/view',
  component:ViewComponent
},
{
  path:'create',
  component:SubmitComponent
},
{
  path:':patientId/edit',
  component:EditComponent
},
]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
