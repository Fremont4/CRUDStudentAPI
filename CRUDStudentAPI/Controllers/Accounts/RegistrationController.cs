using CRUDStudentAPI.App_repositories.Interfaces.Accounts;
using CRUDStudentAPI.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDStudentAPI.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepo _registrationRepo;
        public RegistrationController(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Registration registration)
        {
            return new OkObjectResult(await _registrationRepo.createStudent(registration));
        }
    }
}
