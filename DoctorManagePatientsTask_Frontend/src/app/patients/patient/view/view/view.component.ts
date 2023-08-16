import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Patient } from 'src/app/patients/interfaces/patient';
import { PatientcrudserviceService } from 'src/app/patients/services/patientcrudservice.service';
@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent implements OnInit {
     
  id!: number;
  patient!: Patient;
    
  /*------------------------------------------
  --------------------------------------------
  Created constructor
  --------------------------------------------
  --------------------------------------------*/
  constructor(
    public patientService: PatientcrudserviceService,
    private route: ActivatedRoute,
    private router: Router
   ) { }
    
  /**
   * Write code on Method
   *
   * @return response()
   */
  ngOnInit(): void {
    this.id = this.route.snapshot.params['patientId'];
        
    this.patientService.getById(this.id).subscribe((data: any)=>{
      this.patient = data.data;
    });
  }
}
