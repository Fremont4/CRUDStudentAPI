using CRUDStudentAPI.App_repositories.Interfaces.Accounts;
using CRUDStudentAPI.Data;
using CRUDStudentAPI.Models;
using CRUDStudentAPI.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentAPI.App_repositories.Implementations.Accounts
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly StudentDbContext _studentDbContext;

        public RegistrationRepo(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public async Task<Registration> AccountExists(string studentNo)
        {
            var studentExist = await _studentDbContext.Portal.Where(x => x.StudentNo.Contains(studentNo)).FirstOrDefaultAsync();
            //bool studentExist = false;
            return studentExist;
        }
        public async Task<Registration> createStudent(Registration registration)
        {
       
            await _studentDbContext.Portal.AddAsync(registration);
            await _studentDbContext.SaveChangesAsync();
            return registration;
           
        }

        public bool LoginStudent(Login student)
        {
            var user= _studentDbContext.Portal.Where(x => x.StudentNo.Equals(student.StudentNo) && x.Password.Equals(student.Password)).FirstOrDefault();
            if (user is null)
            {

                return false;
            }
            if (user != null)
            {

                return true;
            }
            return false;
        }

        public string RegisterStudent(Registration registration)
        {
                _studentDbContext.Portal.Add(registration);
                _studentDbContext.SaveChanges(); 


            return "Inserted";
        }

        public Task<Registration> updateStudent(Registration registration)
        {
            throw new NotImplementedException();
        }
    }
}
