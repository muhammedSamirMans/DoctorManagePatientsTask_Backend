using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagePatientsTask_DAL.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
