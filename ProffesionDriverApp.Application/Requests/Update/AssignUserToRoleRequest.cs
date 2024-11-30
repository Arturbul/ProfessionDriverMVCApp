namespace ProfessionDriverApp.Application.Requests.Update
{
    public class AssignUserToRoleRequest
    {
        public string UserName { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}