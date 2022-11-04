using System.ComponentModel.DataAnnotations;

namespace CRUDStudentAPI.Models.Account
{
    
    public class Registration
    {
        [Key]
        public string StudentNo { get; set; }
        public string StudentName { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
