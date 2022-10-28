using CRUDStudentAPI.Models.Account;

namespace CRUDStudentAPI.App_repositories.Interfaces.Accounts
{
    public interface IRegistrationRepo
    {
        Task<Registration> createStudent(Registration registration);
        Task<Registration> updateStudent(Registration registration);

    }
}
