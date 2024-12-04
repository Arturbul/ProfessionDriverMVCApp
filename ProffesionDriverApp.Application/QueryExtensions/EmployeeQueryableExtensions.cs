using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.QueryExtensions
{
    public static class EmployeeQueryableExtensions
    {
        /// <summary>
        /// Sprawdza, czy pracownik jest zatrudniony.
        /// </summary>
        public static IQueryable<Employee> WhereIsEmployed(this IQueryable<Employee> query, DateOnly currentDate)
        {
            return query.Where(e =>
                (e.TerminationDate == null || e.TerminationDate > currentDate) &&
                (e.CompanyId != 0 || !e.Company.IsDeleted));
        }

        /// <summary>
        /// Sprawdza, czy pracownik jest aktywny (zatrudniony i z datą zatrudnienia w przeszłości).
        /// </summary>
        public static IQueryable<Employee> WhereIsActive(this IQueryable<Employee> query, DateOnly currentDate)
        {
            return query.Where(e =>
                (e.TerminationDate == null || e.TerminationDate > currentDate) &&
                e.HireDate <= currentDate &&
                (e.CompanyId != 0 || !e.Company.IsDeleted));
        }
    }

}
