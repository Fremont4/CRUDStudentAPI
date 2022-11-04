using CRUDStudentAPI.App_repositories.Interfaces;
using CRUDStudentAPI.Models;
using CRUDStudentAPI.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDStudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
       private readonly IProfileRepo  _profileRepo;

        public ProfileController(IProfileRepo profileRepo)
        {
            _profileRepo = profileRepo;
        }
        [HttpGet("GetAllStudents")]

        public async Task<ActionResult> GetStudents()
        {
            Response response = new Response();
            
            try
            {
                return new OkObjectResult(await _profileRepo.GetStudents());
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = "Error retrieving data from the database";
                return BadRequest(response);
            }
        }


        [HttpGet("singleUser")]
        public async Task<ActionResult> GetByStudentNo(string studentNo)
        {
            Response response = new Response();
            try
            {
                var result = await _profileRepo.GetByStudentNo(studentNo);

                if (result == null) return NotFound();

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = "Error retrieving data from the database";
                return BadRequest(response);
            }
        }



        [HttpPut("update")]
        public async Task<ActionResult> UpdateEmployee([FromBody] Registration registration)
        {
            Response response = new Response();
            await _profileRepo.UpdateStudent(registration);
            response.Status = true;
            response.Message = "Update Successful";
            return new OkObjectResult(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteStudent(string StudentNo)
        {
            Response response = new Response();
            try
            {
                var delete =await  _profileRepo.GetByStudentNo( StudentNo);
                

                if (delete != null)
                {
                    return new OkObjectResult(await _profileRepo.DeleteStudent(StudentNo));
                }

                return NotFound();
                
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = "Error deleting data from the database";
                return BadRequest(response);
            }
        }

    }
}
