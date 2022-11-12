namespace EmploymentApp.Contracts.BusinessObjects
{
    public class LoginResponse
    {
        public IList<string> Roles { get; set; }
        public string Email { get; set; }
    }
}
