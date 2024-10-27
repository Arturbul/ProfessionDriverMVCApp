namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IList<int>> Get();
    }
}
