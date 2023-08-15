using AutoMapper;
using DoctorManagePatientsTask_Core.DTO;
using DoctorManagePatientsTask_Core.ViewModels.Patients;
using DoctorManagePatientsTask_DAL.Repositories.Interfaces;
using DoctorManagePatientsTask_Domain.Models;
using DoctorManagePatientsTask_Services_BLL.Interfaces.Patients; 

namespace DoctorManagePatientsTask_Services_BLL.Impelementations.Patients
{
    public class PatientService:IPatientService
    {
        #region instances

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Patient> _patientRepository;

        #endregion

        #region Constuctor

        public PatientService(IMapper mapper, IUnitOfWork unitOfWork, IBaseRepository<Patient> patientRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
        }

        #endregion

        #region Business Methods Impelemntations
        
        //Patients List.
        public async Task<CommonResponseDTO> GetAllPatientAsync(int currentPage, int pageSize)
        {
            try
            {
                var TotalCount = _patientRepository.GetTotalCountAsync(patient => patient.Deleted == false);
                //get all unDeleted Patients From Repo
                var _list = await _patientRepository.GetAllAsync(patient=> patient.Deleted == false, currentPage, pageSize);
                //Mapping the repo response to viewModel list.
                var Patients = _mapper.Map<List<PatientVM>>(_list);
                //make an object contain total count of patiens and patients objects to return it to the API As Comman response.
                var _data = new { TotalCount, Patients };
                return new CommonResponseDTO { Status = 200, Message = "Success", Data = _data };
            }
            catch (Exception ex)
            {
                return new CommonResponseDTO { Status = 500, Message = "Server Error", Data = ex };
            }
        }
        //Patient by Id.
        public async Task<CommonResponseDTO> GetPatientByIdsync(int patientId)
        {
            try
            {
                var _Patient = await _patientRepository.FirstOrDefaultAsync(c => c.Id == patientId && c.Deleted == false);
                if (_Patient == null)
                    return new CommonResponseDTO { Status = 404, Message = "Not Found" };

                var _data = _mapper.Map<PatientVM>(_Patient);
                return new CommonResponseDTO { Status = 200, Message = "Success", Data = _data };
            }
            catch (Exception ex)
            {
                return new CommonResponseDTO { Status = 500, Message = "Server Error", Data = ex };
            }
        }
        //Patient Create.
        public async Task<CommonResponseDTO> CreatePatientAsync(PatientVM patientVM)
        {
            try
            {
                var obj = _mapper.Map<Patient>(patientVM);
                obj.Deleted = false;
                obj.CreationDate = DateTime.Now;
                obj.CreatorAccountId = "";
                obj.ModifictionDate = DateTime.Now;
                obj.ModifierAccountId = "";
                await _patientRepository.AddAsync(obj);
                await _unitOfWork.SaveChangesAsync();
                return new CommonResponseDTO { Status = 200, Message = "Your Data Saved successfully" };
            }
            catch (Exception ex)
            {
                return new CommonResponseDTO { Status = 500, Message = "Server Error", Data = ex };
            }
        }
        //Patient Update.
        public async Task<CommonResponseDTO> UpdatePatientAsync(PatientVM patientVM)
        {
            try
            {
                //get the patient from db using it id.
                var patient = await _patientRepository.FirstOrDefaultAsync(c => c.Id == patientVM.Id && c.Deleted == false);
                //if the search result is null that mean that patient not found.
                if(patient == null)
                    return new CommonResponseDTO { Status = 404, Message = "Patient not found." };
                //asign only the new data to the patient and the other important data will not effects like creatorId and creationDate and so on.
                #region data of patient that we need to update

                #region Enitity Data
                //Data log the modifection Date And UserActionID.
                patient.ModifictionDate = DateTime.Now;
                patient.ModifierAccountId = "";

                #endregion

                #region Basic Information

                patient.PasNumber = patientVM.PasNumber; 
                patient.Forenames = patientVM.Forenames; 
                patient.Surname = patientVM.Surname; 
                patient.DateOfBirth = patientVM.DateOfBirth; 
                patient.SexCode = patientVM.SexCode;  
                patient.HomeTelephoneNumber = patientVM.HomeTelephoneNumber;

                #endregion

                #region NextOfKin
                  
                patient.NokName = patientVM.NokName; 
                patient.NokRelationshipCode = patientVM.NokRelationshipCode;  
                patient.NokAddressLine1 = patientVM.NokAddressLine1;  
                patient.NokAddressLine2 = patientVM.NokAddressLine2; 
                patient.NokAddressLine3 = patientVM.NokAddressLine3;  
                patient.NokAddressLine4 = patientVM.NokAddressLine4;  
                patient.NokPostcode = patientVM.NokPostcode;

                #endregion

                #region GpDetails
                 
                patient.GpCode = patientVM.GpCode; 
                patient.GpSurname = patientVM.GpSurname; 
                patient.GpInitials = patientVM.GpInitials; 
                patient.GpPhone = patientVM.GpPhone;

                #endregion 

                #endregion
                await _patientRepository.UpdateAsync(patient);
                await _unitOfWork.SaveChangesAsync();
                return new CommonResponseDTO { Status = 200, Message = "Your Data Saved successfully" };
            }
            catch (Exception ex)
            {
                return new CommonResponseDTO { Status = 500, Message = "Server Error", Data = ex };
            }
        }
        //Patient Delete.
        public async Task<CommonResponseDTO> DeletePatientAsync(int patientId)
        {
            try
            {
                //get the patient from db using it id.
                var patient = await _patientRepository.FirstOrDefaultAsync(c => c.Id == patientId && c.Deleted == false);
                //if the search result is null that mean that patient not found.
                if (patient == null)
                    return new CommonResponseDTO { Status = 404, Message = "Patient not found." };
                //asign only the new data to the patient and the other important data will not effects like creatorId and creationDate and so on.
                #region data of patient that we need to Delete
                  
                //Data log the Deleted Date And UserActionID. in this case if the flag is ture then the last modifictionDate is the deleted date bucouse we no longer allow user operations on deleted item
                patient.ModifictionDate = DateTime.Now;
                patient.ModifierAccountId = "";
                //Make Delete flag true.
                patient.Deleted = true; 

                #endregion
                await _patientRepository.UpdateAsync(patient);
                await _unitOfWork.SaveChangesAsync();
                return new CommonResponseDTO { Status = 200, Message = "Your Patient Deleted successfully." };
            }
            catch (Exception ex)
            {
                return new CommonResponseDTO { Status = 500, Message = "Server Error.", Data = ex };
            }
        }
        #endregion
    }
}
