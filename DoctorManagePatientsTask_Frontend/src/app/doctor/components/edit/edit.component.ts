import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import Swal from 'sweetalert2';
import { Patient } from '../../interfaces/patient';
import { PatientcrudserviceService } from '../../services/patientcrudservice.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent {

  id!: number;
  patient!: Patient;
  form!: FormGroup;

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
      this.form.patchValue(this.patient);
    });

    this.form = new FormGroup({
      id: new FormControl('', [Validators.required]),
      pasNumber: new FormControl('', [Validators.required]),
      forenames: new FormControl('', Validators.required),
      surname: new FormControl('', Validators.required),
      dateOfBirth: new FormControl('', Validators.required),
      sexCode: new FormControl('', Validators.required),
      homeTelephoneNumber: new FormControl('', Validators.required),
      nokName: new FormControl('', Validators.required),
      nokRelationshipCode: new FormControl('', Validators.required),
      nokAddressLine1: new FormControl('', Validators.required),
      nokAddressLine2: new FormControl('', Validators.required),
      nokAddressLine3: new FormControl('', Validators.required),
      nokAddressLine4: new FormControl('', Validators.required),
      nokPostcode: new FormControl('', Validators.required),
      gpCode: new FormControl('', Validators.required),
      gpSurname: new FormControl('', Validators.required),
      gpInitials: new FormControl('', Validators.required),
      gpPhone: new FormControl('', Validators.required)
    });
  }

  /**
   * Write code on Method
   *
   * @return response()
   */
  get f(){
    return this.form.controls;
  }

  /**
   * Write code on Method
   *
   * @return response()
   */
  submit(){
    console.log(this.form.value);
    this.patientService.submit(this.form.value).subscribe((res:any) => {
         Swal.fire('updated!', 'updated successfully.', 'success');
         this.router.navigateByUrl('/doctor');
    })
  }

}
