using CRUDStudentAPI.Models.Account;

namespace CRUDStudentAPI.App_repositories.Interfaces
{
    public interface IProfileRepo
    {
        Task<IEnumerable<Registration>> GetStudents();
        Task<Registration> UpdateStudent(Registration registration);
        Task<Registration> GetByStudentNo(string StudentNo);

        Task<Registration> DeleteStudent(string StudentNo);
    }
}
