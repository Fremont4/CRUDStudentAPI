using CRUDStudentAPI.Models.Account;

namespace CRUDStudentAPI.App_repositories.Interfaces.Accounts
{
    public interface ILoginRepo
    {
        Task<Login> LoginStudent(Login student);
        Task<Login> LogoutStudent(Login student);
        Task<bool> AccountExists(string studentNo);
    }
}
