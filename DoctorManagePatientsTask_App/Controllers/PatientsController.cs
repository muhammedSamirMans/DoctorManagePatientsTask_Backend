using DoctorManagePatientsTask_Core.DTO;
using DoctorManagePatientsTask_Core.ViewModels.Patients;
using DoctorManagePatientsTask_Services_BLL.Interfaces.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagePatientsTask_App.Controllers
{
    [Route("api/Patient")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        #region Instances
        private readonly IPatientService _patientService;
        #endregion

        #region Constractor
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        #endregion

        #region Business Web APIs Methods
        [HttpGet]
        [Route("GetAll/currentPage/{currentPage}/pageSize/{pageSize}")]
        public async Task<IActionResult> GetAll([FromRoute] int currentPage, [FromRoute] int pageSize)
        {
            //Declare instances
            CommonResponseDTO response = new CommonResponseDTO();
            try
            {
                //Get All Patient Using method from patient service.
                response = await _patientService.GetAllPatientAsync(currentPage, pageSize);
            }
            catch(Exception ex)
            {
                response = new CommonResponseDTO
                {
                    Status = 500,
                    Message = "server Error",
                    Data = ex
                };
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SavePatient([FromBody] PatientVM patientVM)
        {
            //instance
            CommonResponseDTO response = new CommonResponseDTO();
            try
            {
                //Check if the process is patient creation or patient modifection
                if (patientVM.Id == 0)
                    //Call The Creation Process That impelemented in patient service.
                    response = await _patientService.CreatePatientAsync(patientVM);
                else
                    //Call The Modifection Process That impelemented in patient service.
                    response = await _patientService.UpdatePatientAsync(patientVM);
            }
            catch (Exception ex)
            {
                response = new CommonResponseDTO
                {
                    Status = 500,
                    Message = "server Error",
                    Data = ex
                };
            }
            return Ok(response);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePatient([FromBody] int patientId)
        {
            CommonResponseDTO response = new CommonResponseDTO();
            try
            {
                response = await _patientService.DeletePatientAsync(patientId);
            }
            catch(Exception ex)
            {
                response = new CommonResponseDTO
                {
                    Status = 500,
                    Message = "Server Error.",
                    Data = ex
                };
            }
            return Ok(response);
        }
        #endregion
    }
}
