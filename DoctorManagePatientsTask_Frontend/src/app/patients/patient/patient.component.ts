import { Component, OnInit } from '@angular/core';
import { Patient } from '../interfaces/patient'; 
import { DatePipe } from '@angular/common';
import { FormBuilder, Validators } from '@angular/forms';
import { PatientcrudserviceService } from '../services/patientcrudservice.service';
import Swal from 'sweetalert2';
interface PageEvent {
  first: number;
  rows: number;
  page: number;
  pageCount: number;
}
@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss'] ,
  providers:[DatePipe]
})
export class PatientComponent implements OnInit
 {
  patients: Patient[] = [];
  page:number =0;
  /*------------------------------------------
  --------------------------------------------
  Created constructor
  --------------------------------------------
  --------------------------------------------*/
  constructor(public patientService: PatientcrudserviceService) { }
    
  /**
   * Write code on Method
   *
   * @return response()
   */
  ngOnInit(): void 
  {
    this.getAllPatients();
  } 

  getAllPatients(){
    this.patientService.getAll().subscribe((data:any)=>
    {
      this.patients = data.data.patients;
      console.log(this.patients);
    });
  }
  delete(id?:number){

    Swal.fire({
      title: 'Are you sure?',
      text: 'This process is irreversible.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, remove it.',
      cancelButtonText: 'No, let me think'
    }).then((result) => {
      this.patientService.delete(id).subscribe((res:any) => 
        {
           console.log(res);
            if (res.status == 200) 
            {
              Swal.fire('Removed!', 'removed successfully.', 'success');
            this.getAllPatients();
            } else if (result.dismiss === Swal.DismissReason.cancel) {
              Swal.fire('Cancelled', ' still in our database.', 'error');
            }
           
      }) ;
      
    });
    
  }
  gty(page: any){
    // this.GenericServiceService.getAllData(`https://api.instantwebtools.net/v1/passenger?page=${page}&size=${this.itemsPerPage}`).subscribe((data: any) => {
    //   this.list =  data.data;
    //   this.totalItems = data.totalItem;
    // })
  }
}
