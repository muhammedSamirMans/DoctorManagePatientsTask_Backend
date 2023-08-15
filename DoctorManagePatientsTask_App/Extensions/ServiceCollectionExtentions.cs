using DoctorManagePatientsTask_DAL.Repositories.Impelementations;
using DoctorManagePatientsTask_DAL.Repositories.Interfaces;
using DoctorManagePatientsTask_Services_BLL.Impelementations.Patients;
using DoctorManagePatientsTask_Services_BLL.Interfaces.Patients;

namespace DoctorManagePatientsTask_App.Extensions
{
    //Registering a factory throw extention method.
    public static class ServiceCollectionExtentions
    {
        //registering all interfaces and service types.
        public static IServiceCollection RegisterDependancy(this IServiceCollection services)
        {
            #region Repositories 
            //UnitOfWork, AddScoped To User The Same Object When Requested within same request
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //BaseRepository, AddScoped To User The Same Object When Requested within same request
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            #endregion

            #region Services
            // Patient service, AddScoped To User The Same Object When Requested within same request 
            services.AddScoped<IPatientService, PatientService>();
            #endregion

            return services;
        }
    }
}
