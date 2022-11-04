namespace CRUDStudentAPI.Models.Account
{
    public record Login
    {
        public string StudentNo { get; set; }
        public string Password { get; set; }
    }
}
