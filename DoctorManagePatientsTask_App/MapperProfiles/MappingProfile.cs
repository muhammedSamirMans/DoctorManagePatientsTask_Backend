using AutoMapper;
using DoctorManagePatientsTask_Core.ViewModels.Patients;
using DoctorManagePatientsTask_Domain.Models;

namespace DoctorManagePatientsTask_App.MapperProfiles
{
    public class MappingProfile : Profile
    {
        //Mapping Profile Constructor (Excute Auto when create new instance of mapper)
        public MappingProfile()
        {
            //Call Mapping Settings.
            #region Patient
            _Patient();
            #endregion
        }
        //Start to Emplement Mapping Settings.
        #region Patient
        void _Patient()
        { 
            CreateMap<PatientVM, Patient>().ReverseMap(); 
        }
        #endregion

    }
}
