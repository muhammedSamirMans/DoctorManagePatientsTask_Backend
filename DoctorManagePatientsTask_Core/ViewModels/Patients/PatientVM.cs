using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagePatientsTask_Core.ViewModels.Patients
{
    public class PatientVM
    {
        //We Can Applay any needed validations if we have the format of each prop.
        #region Enitity Data
        public int? Id { get; set; }
        #endregion
        #region Basic Information

        [Required]
        public string PasNumber { get; set; }
        [Required]
        public string Forenames { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public char SexCode { get; set; }
        [Required]
        public string HomeTelephoneNumber { get; set; }

        #endregion

        #region NextOfKin

        [Required]
        public string NokName { get; set; }
        [Required]
        public string NokRelationshipCode { get; set; }
        [Required]
        public string NokAddressLine1 { get; set; }
        [Required]
        public string NokAddressLine2 { get; set; }
        [Required]
        public string NokAddressLine3 { get; set; }
        [Required]
        public string NokAddressLine4 { get; set; }
        [Required]
        public string NokPostcode { get; set; }

        #endregion

        #region GpDetails

        [Required]
        public int GpCode { get; set; }
        [Required]
        public string GpSurname { get; set; }
        [Required]
        public string GpInitials { get; set; }
        [Required]
        public string GpPhone { get; set; }

        #endregion
    }
}
