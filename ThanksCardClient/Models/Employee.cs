#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Employee : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region CdProperty
        private long _EmployeeCd;
        public long EmployeeCd
        {
            get { return _EmployeeCd; }
            set { SetProperty(ref _EmployeeCd, value); }
        }
        #endregion

        #region NameProperty
        private string Employee;
        public string EmployeeName
        {
            get { return Employee; }
            set { SetProperty(ref Employee, value); }
        }
        #endregion

        #region Furiganaperty
        private string Furigana;
        public string Furiganas
        {
            get { return Furiganas; }
            set { SetProperty(ref Furiganas, value); }
        }
        #endregion

        #region PasswordProperty
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        #endregion

        #region IsAdminProperty
        private bool _IsAdmin;
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set { SetProperty(ref _IsAdmin, value); }
        }
        #endregion

        #region OrganizationIdProperty
        private long? OrganizationId;
        public long? OrganizationId
        {
            get { return OrganizationId; }
            set { SetProperty(ref OrganizationId, value); }
        }
        #endregion

        #region OrganizationProperty
        private Organization _Organization;
        public Organization Organizations
        {
            get { return Organization; }
            set { SetProperty(ref Organization, value); }
        }
        #endregion

        public async Task<Employee> LogonAsync()
        {
            IRestService rest = new RestService();
            Employee authorizedEmployee = await rest.LogonAsync(this);
            return authorizedEmployee;
        }

        public async Task<List<Employee>> GetOrganizationUsersAsync(long? DepartmentId)
        {
            IRestService rest = new RestService();
            List<Employee> Employees = await rest.GetOrganizationUsersAsync(DepartmentId);
            return Employees;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            IRestService rest = new RestService();
            List<Employee> Employees = await rest.GetEmployeesAsync();
            return Employees;
        }

        public async Task<Employee> PostUserAsync(Employee Employees)
        {
            IRestService rest = new RestService();
            Employee createdEmployee = await rest.PostEmployeeAsync(Employees);
            return createdEmployee;
        }

        public async Task<Employee> PutEmployeeAsync(Employee Employees)
        {
            IRestService rest = new RestService();
            Employee updatedEmployee = await rest.PutEmployeeAsync(Employees);
            return updatedEmployee;
        }

        public async Task<Employee> DeleteEmployeeAsync(long Id)
        {
            IRestService rest = new RestService();
            Employee deletedEmployee = await rest.DeleteEmployeeAsync(Id);
            return deletedEmployee;
        }
    }
}
