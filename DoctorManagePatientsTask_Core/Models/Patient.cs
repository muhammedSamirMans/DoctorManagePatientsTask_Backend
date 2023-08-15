using DoctorManagePatientsTask_Domain.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagePatientsTask_Domain.Models
{
    public class Patient:BaseModel
    {
        #region Basic Information

        //making length of 9 becouse  passport number length is usually nine characters this will be good at memory management(low speace in DB).
        [MaxLength(9, ErrorMessage = "maximum {1} characters allowed.")]
        public string PasNumber { get; set; }
        //making length of 25 becouse  Forenames  length is usually 25 characters this will be good at memory management(low speace in DB).
        [MaxLength(25, ErrorMessage = "maximum {1} characters allowed.")]
        public string Forenames { get; set; }
        //making length of 25 becouse  Surname  length is usually 25 characters this will be good at memory management(low speace in DB).
        [MaxLength(25, ErrorMessage = "maximum {1} characters allowed.")]
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        //Since The Coding Values:  F = Female  M = Male N = Non Binary so i just need only on Char for represinting Sex Code.
        public char SexCode { get; set; }
        //just put it 50 as max till know (ask for)  Phone Format (it's differnce from countory and other).
        [MaxLength(50, ErrorMessage = "maximum {1} characters allowed.")]
        public string HomeTelephoneNumber { get; set; } 

        #endregion

        #region NextOfKin

        //making length of 50  will be good at memory management(low speace in DB).
        [MaxLength(50, ErrorMessage = "maximum {1} characters allowed.")]
        public string NokName { get; set; }
        [MaxLength(100, ErrorMessage = "maximum {1} characters allowed.")]
        public string NokRelationshipCode { get; set; }
        [MaxLength(250, ErrorMessage = "maximum {1} characters allowed.")]
        public string NokAddressLine1 { get; set; }
        [MaxLength(250, ErrorMessage = "maximum {1} characters allowed.")]
        public string NokAddressLine2 { get; set; }
        [MaxLength(250, ErrorMessage = "maximum {1} characters allowed.")]
        public string NokAddressLine3 { get; set; }
        [MaxLength(250, ErrorMessage = "maximum {1} characters allowed.")]
        public string NokAddressLine4 { get; set; }
        [MaxLength(80, ErrorMessage = "maximum {1} characters allowed.")]
        public string NokPostcode { get; set; }

        #endregion

        #region GpDetails

        [MaxLength(100, ErrorMessage = "maximum {1} characters allowed.")]
        public int GpCode { get; set; }
        [MaxLength(100, ErrorMessage = "maximum {1} characters allowed.")]
        public string GpSurname { get; set; }
        [MaxLength(100, ErrorMessage = "maximum {1} characters allowed.")]
        public string GpInitials { get; set; }
        [MaxLength(100, ErrorMessage = "maximum {1} characters allowed.")]
        public string GpPhone { get; set; }

        #endregion
    }
}
