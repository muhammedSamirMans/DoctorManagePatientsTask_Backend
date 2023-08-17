import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientcrudserviceService } from '../../services/patientcrudservice.service';
import { Patient } from '../../interfaces/patient';
@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent {
  id!: number;
  patient!: Patient;
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
