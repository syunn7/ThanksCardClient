#nullable disable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using System.Net.Http.Json;

namespace ThanksCardClient.Services
{
    class RestService : IRestService
    {
        private HttpClient Client;
        private string BaseUrl;

        public RestService()
        {
            // Setting: "Do not use proxy"
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseProxy = false;

            this.Client = new HttpClient(handler);
            this.BaseUrl = "https://localhost:5000";
        }
        public async Task<Employee> LogonAsync(Employee employee)
        {
            Employee responseEmployee = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/Logon", employee);
                if (response.IsSuccessStatusCode)
                {
                    responseEmployee = await response.Content.ReadFromJsonAsync<Employee>();
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync: " + e);
            }
            return responseEmployee;
        }

        public async Task<List<Employee>> GetOrganizationUsersAsync(long? OrganizationId)
        {
            List<Employee> responseEmployees = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/OrganizationUsers/" + OrganizationId);
                if (response.IsSuccessStatusCode)
                {
                    responseEmployees = await response.Content.ReadFromJsonAsync<List<Employee>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetEmployeesAsync: " + e);
            }
            return responseEmployees;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> responseEmployees = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Employee");
                if (response.IsSuccessStatusCode)
                {
                    responseEmployees = await response.Content.ReadFromJsonAsync<List<Employee>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetEmployeesAsync: " + e);
            }
            return responseEmployees;
        }

        public async Task<Employee> PostEmployeeAsync(Employee employee)
        {
            Employee responseEmployee = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/Employee", employee);
                if (response.IsSuccessStatusCode)
                {
                    responseEmployee = await response.Content.ReadFromJsonAsync<Employee>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostEmployeeAsync: " + e);
            }
            return responseEmployee;
        }

        public async Task<Employee> PutEmployeeAsync(Employee employee)
        {
            Employee responseEmployee = null;
            try
            {
                var response = await Client.PutAsJsonAsync(this.BaseUrl + "/api/Employee/" + employee.Id, employee);
                if (response.IsSuccessStatusCode)
                {
                    responseEmployee = await response.Content.ReadFromJsonAsync<Employee>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutEmployeeAsync: " + e);
            }
            return responseEmployee;
        }

        public async Task<Employee> DeleteEmployeeAsync(long Id)
        {
            Employee responseEmployee = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Employee/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    responseEmployee = await response.Content.ReadFromJsonAsync<Employee>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteEmployeeAsync: " + e);
            }
            return responseEmployee;
        }

        public async Task<List<Organization>> GetOrganizationsAsync()
        {
            List<Organization> responseOrganizations = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Organization");
                if (response.IsSuccessStatusCode)
                {
                    responseOrganizations = await response.Content.ReadFromJsonAsync<List<Organization>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetOrganizationsAsync: " + e);
            }
            return responseOrganizations;
        }

        public async Task<Organization> PostOrganizationAsync(Organization organization)
        {
            Organization responseOrganization = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/Organization", organization);

                if (response.IsSuccessStatusCode)
                {
                    responseOrganization = await response.Content.ReadFromJsonAsync<Organization>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostOrganizationAsync: " + e);
            }
            return responseOrganization;
        }

        public async Task<Organization> PutOrganizationAsync(Organization organization)
        {
            Organization responseOrganization = null;
            try
            {
                var response = await Client.PutAsJsonAsync(this.BaseUrl + "/api/Organization/" + organization.Id, organization);
                if (response.IsSuccessStatusCode)
                {
                    responseOrganization = await response.Content.ReadFromJsonAsync<Organization>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutOrganizationAsync: " + e);
            }
            return responseOrganization;
        }

        public async Task<Organization> DeleteOrganizationAsync(long Id)
        {
            Organization responseOrganization = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Organization/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    responseOrganization = await response.Content.ReadFromJsonAsync<Organization>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteOrganizationAsync: " + e);
            }
            return responseOrganization;
        }

        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            List<ThanksCard> responseThanksCards = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/ThanksCards");
                if (response.IsSuccessStatusCode)
                {
                    responseThanksCards = await response.Content.ReadFromJsonAsync<List<ThanksCard>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetThanksCardsAsync: " + e);
            }
            return responseThanksCards;
        }

        public async Task<List<ThanksCard>> PostSearchThanksCardsAsync(SearchThanksCard searchThanksCard)
        {
            List<ThanksCard> responseThanksCards = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/SearchThanksCard", searchThanksCard);
                if (response.IsSuccessStatusCode)
                {
                    responseThanksCards = await response.Content.ReadFromJsonAsync<List<ThanksCard>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetThanksCardsAsync: " + e);
            }
            return responseThanksCards;
        }


        public async Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard)
        {
            ThanksCard responseThanksCard = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/ThanksCards", thanksCard);
                if (response.IsSuccessStatusCode)
                {
                    responseThanksCard = await response.Content.ReadFromJsonAsync<ThanksCard>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostThanksCardAsync: " + e);
            }
            return responseThanksCard;
        }

        public async Task<List<Classification>> GetClassificationsAsync()
        {
            List<Classification> responseClassifications = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Classification");
                if (response.IsSuccessStatusCode)
                {
                    responseClassifications = await response.Content.ReadFromJsonAsync<List<Classification>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetClassificationsAsync: " + e);
            }
            return responseClassifications;
        }

        public async Task<Classification> PostClassificationAsync(Classification classification)
        {
            Classification responseClassification = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/Classification", classification);
                if (response.IsSuccessStatusCode)
                {
                    responseClassification = await response.Content.ReadFromJsonAsync<Classification>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostClassificationAsync: " + e);
            }
            return responseClassification;
        }

        public async Task<Classification> PutClassificationAsync(Classification classification)
        {
            Classification responseClassification = null;
            try
            {
                var response = await Client.PutAsJsonAsync(this.BaseUrl + "/api/Classification/" + classification.Id, classification);
                if (response.IsSuccessStatusCode)
                {
                    responseClassification = await response.Content.ReadFromJsonAsync<Classification>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutClassificationAsync: " + e);
            }
            return classification;
        }

        public async Task<Classification> DeleteClassificationAsync(long Id)
        {
            Classification responseClassification = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Classification/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    responseClassification = await response.Content.ReadFromJsonAsync<Classification>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteClassificationAsync: " + e);
            }
            return responseClassification;
        }
    }
}
