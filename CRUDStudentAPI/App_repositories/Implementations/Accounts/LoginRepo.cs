using CRUDStudentAPI.App_repositories.Interfaces.Accounts;
using CRUDStudentAPI.Models.Account;

namespace CRUDStudentAPI.App_repositories.Implementations.Accounts
{
    public class LoginRepo : ILoginRepo
    {
        public Task<bool> AccountExists(string studentNo)
        {
            throw new NotImplementedException();
        }

        public Task<Login> LoginStudent(Login student)
        {
            throw new NotImplementedException();
        }

        public Task<Login> LogoutStudent(Login student)
        {
            throw new NotImplementedException();
        }
    }
}
