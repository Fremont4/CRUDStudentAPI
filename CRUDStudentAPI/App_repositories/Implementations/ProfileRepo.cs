using CRUDStudentAPI.App_repositories.Interfaces;
using CRUDStudentAPI.Data;
using CRUDStudentAPI.Models.Account;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CRUDStudentAPI.App_repositories.Implementations
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly StudentDbContext _studentDbContext;

        public ProfileRepo(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public  async Task<Registration> DeleteStudent(string StudentNo)
        {

            var deleteStudent = _studentDbContext.Portal.Find(StudentNo);
             _studentDbContext.Portal.Remove(deleteStudent);
            await _studentDbContext.SaveChangesAsync();
            return (deleteStudent);
            

        }

        public async Task<Registration> GetByStudentNo(string StudentNo)
        {
            return await _studentDbContext.Portal.FirstOrDefaultAsync(x => x.StudentNo == StudentNo);
        }

        public async Task<IEnumerable<Registration>> GetStudents()
        {
            return await _studentDbContext.Portal.ToListAsync();
        }

        public async Task<Registration> UpdateStudent(Registration registration)
        {
            var user =await _studentDbContext.Portal.FirstOrDefaultAsync(x => x.StudentNo == registration.StudentNo);
            if (user != null)
            {
                user.Email = registration.Email;
                user.StudentName = registration.StudentName;
                user.Password = registration.Password;
                user.ConfirmPassword = registration.ConfirmPassword;

                await _studentDbContext.SaveChangesAsync();
                return user;

            }
            return null;
        }
    }
}
