using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

namespace ThanksCardClient.Services
{
    interface IRestService
    {
        // Logon REST API Client
        Task<Employee> LogonAsync(Employee Employees);

        // DepartmentUsers REST API Client
        Task<List<Employee>> GetOrganizationUsersAsync(long? OrganizationId);

        // User REST API Client
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> PostEmployeeAsync(Employee Employees);
        Task<Employee> PutEmployeeAsync(Employee Employees);
        Task<Employee> DeleteEmployeeAsync(long Id);

        // Department REST API Client
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> PostDepartmentAsync(Department department);
        Task<Department> PutDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(long Id);

        // TanksCard REST API Client
        Task<List<ThanksCard>> GetThanksCardsAsync();
        Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard);

        // Tag REST API Client
        Task<List<Classification>> GetClassificationsAsync();
        Task<Classification> PostClassificationAsync(Classification Classifications);
        Task<Classification> PutClassificationAsync(Classification Classifications);
        Task<Classification> DeleteClassificationAsync(long Id);
    }
}
