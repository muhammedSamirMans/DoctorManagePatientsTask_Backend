using DoctorManagePatientsTask_DAL.Repositories.Interfaces;
using DoctorManagePatientsTask_DAL.Context;

namespace DoctorManagePatientsTask_DAL.Repositories.Impelementations
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
