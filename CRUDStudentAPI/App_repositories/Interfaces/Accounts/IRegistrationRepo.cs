using CRUDStudentAPI.Models.Account;

namespace CRUDStudentAPI.App_repositories.Interfaces.Accounts
{
    public interface IRegistrationRepo
    {
        Task<Registration> createStudent(Registration registration);
        string RegisterStudent(Registration registration);
        bool LoginStudent(Login student);
        Task<Registration> updateStudent(Registration registration);
        Task<Registration> AccountExists(string studentNo);

    }
}
