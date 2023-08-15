using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagePatientsTask_Domain.Models.BaseEntity
{
    public class BaseModel
    {   
        [Key]
        public int Id { get; set; }
        public bool Deleted { get; set; }
        //The defualt .NET Core Identity ID column in nvarchar 450
        [MaxLength(450)]
        public string CreatorAccountId { get; set; }
        //The defualt .NET Core Identity ID column in nvarchar 450
        [MaxLength(450)]
        public string ModifierAccountId { get; set; }  
        public DateTime CreationDate { get; set; }
        public DateTime ModifictionDate { get; set; }
    }
}
