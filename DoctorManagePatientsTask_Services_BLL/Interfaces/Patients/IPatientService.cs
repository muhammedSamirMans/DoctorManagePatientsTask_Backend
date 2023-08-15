using DoctorManagePatientsTask_Core.DTO;
using DoctorManagePatientsTask_Core.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagePatientsTask_Services_BLL.Interfaces.Patients
{
    public interface IPatientService
    {
        //Creation Of Patient Service Interface.
        Task<CommonResponseDTO> CreatePatientAsync(PatientVM patientVM);
        //Update Of Patient Service Interface.
        Task<CommonResponseDTO> UpdatePatientAsync(PatientVM patientVM);
        //Delete Patient By making Delete flag to ture.
        Task<CommonResponseDTO> DeletePatientAsync(int patientId);
        //Get All Patients List with Pagination Interface.
        Task<CommonResponseDTO> GetAllPatientAsync(int currentPage, int pageSize);
        //Get Specifice Patient From Patients list using patientId Interface.
        Task<CommonResponseDTO> GetPatientByIdsync(int patientId); 
    }
}
