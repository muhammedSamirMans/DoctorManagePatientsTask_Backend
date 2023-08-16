import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from '../interfaces/patient';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class PatientcrudserviceService {

  constructor(public http: HttpClient) { }
  getAll(){
    return this.http.get(environment.apiURL+"/api/Patient/GetAll/currentPage/1/pageSize/100000");
   }
  getById(patientId?:number){
    return this.http.get(environment.apiURL+"/api/Patient/GetById/patientId/"+ patientId?.toString());
  }
  submit(data:Patient){
     return this.http.post(environment.apiURL+"/api/Patient/Save", data);
   } 
   delete(patientId?:number)
   { 
     return this.http.delete(environment.apiURL+"/api/Patient/Delete/patientId/" + patientId?.toString());
   }
}
