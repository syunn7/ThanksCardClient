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
        Task<Employee> LogonAsync(Employee employee);

        // DepartmentUsers REST API Client
        Task<List<Employee>> GetOrganizationUsersAsync(long? OrganizationId);

        // User REST API Client
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> PostEmployeeAsync(Employee employee);
        Task<Employee> PutEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeAsync(long Id);

        // Department REST API Client
        Task<List<Organization>> GetOrganizationsAsync();
        Task<Organization> PostOrganizationAsync(Organization organization);
        Task<Organization> PutOrganizationAsync(Organization organization);
        Task<Organization> DeleteOrganizationAsync(long Id);

        // TanksCard REST API Client
        Task<List<ThanksCard>> GetThanksCardsAsync();
        Task<List<ThanksCard>> PostSearchThanksCardsAsync(SearchThanksCard searchThanksCard);
        Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard);

        // Tag REST API Client
        Task<List<Classification>> GetClassificationsAsync();
        Task<Classification> PostClassificationAsync(Classification Classifications);
        Task<Classification> PutClassificationAsync(Classification Classifications);
        Task<Classification> DeleteClassificationAsync(long Id);
    }
}