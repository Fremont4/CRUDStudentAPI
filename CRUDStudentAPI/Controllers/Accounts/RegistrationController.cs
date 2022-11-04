using CRUDStudentAPI.App_repositories.Interfaces.Accounts;
using CRUDStudentAPI.Data;
using CRUDStudentAPI.Models;
using CRUDStudentAPI.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentAPI.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepo _registrationRepo;
        private readonly StudentDbContext _studentDbContext;

        public RegistrationController(IRegistrationRepo registrationRepo, StudentDbContext studentDbContext)
        {
            _registrationRepo = registrationRepo;
            _studentDbContext = studentDbContext;
        }

       

        //[HttpPost]
        //public async Task<IActionResult> CreateStudent([FromBody] Registration registration)
        //{
            
        //    Response response = new Response();
        //    try
        //    {
        //        //checks if the account already exists.
        //        var studentExist = await _studentDbContext.Portal.Where(x => x.StudentNo.Contains(registration.StudentNo)).FirstOrDefaultAsync();

        //        if (studentExist != null)
        //            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = false, Message = "User already exists!" });


        //        await _registrationRepo.createStudent(registration);
        //        response.Status = true;
        //        response.Message = "successful";
        //        return new OkObjectResult(response);
        //    }
        //    catch (Exception)
        //    {
        //        response.Status = false;
        //        response.Message = "failed";
        //        return BadRequest(response);
        //    }
            
        //}
        [HttpPost("register")]
        public  IActionResult RegisterStudent([FromBody] Registration registration)
        {
            return new OkObjectResult(_registrationRepo.RegisterStudent(registration));
        }
        [HttpPost("login")]
        public IActionResult LoginStudent([FromBody] Login login)
        {
            Response response =new Response();
            try
            {
                if (_registrationRepo.LoginStudent(login))
                {
                    response.Status = true;
                    response.Message = "Login successful";
                    return new OkObjectResult(response);
                }
                else
                {
                    response.Status = false;
                    response.Message = "Login failed";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }

}
