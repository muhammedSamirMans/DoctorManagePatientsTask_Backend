import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import Swal from 'sweetalert2';
import { PatientcrudserviceService } from '../../services/patientcrudservice.service';
@Component({
  selector: 'app-submit',
  templateUrl: './submit.component.html',
  styleUrls: ['./submit.component.scss']
})
export class SubmitComponent {
  form!: FormGroup;

  /*------------------------------------------
  --------------------------------------------
  Created constructor
  --------------------------------------------
  --------------------------------------------*/
  constructor(
    public patientService: PatientcrudserviceService,
    private router: Router
  ) { }

  /**
   * Write code on Method
   *
   * @return response()
   */
  ngOnInit(): void
  {
    this.form = new FormGroup(
    {
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
  submit()
  {
    console.log(this.form.value);
    this.patientService.submit(this.form.value).subscribe((res:any) =>
    {
         Swal.fire('created!', 'created successfully.', 'success');
         this.router.navigateByUrl('/doctor');
    })
  }

}
