using CRUDStudentAPI.App_repositories.Interfaces.Accounts;
using CRUDStudentAPI.Models.Account;

namespace CRUDStudentAPI.App_repositories.Implementations.Accounts
{
    public class RegistrationRepo : IRegistrationRepo
    {
        public Task<Registration> createStudent(Registration registration)
        {
            throw new NotImplementedException();
        }

        public Task<Registration> updateStudent(Registration registration)
        {
            throw new NotImplementedException();
        }
    }
}
