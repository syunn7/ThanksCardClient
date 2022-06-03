
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
        private string _EmployeeCd;
        public string EmployeeCd
        {
            get { return _EmployeeCd; }
            set { SetProperty(ref _EmployeeCd, value); }
        }
        #endregion

        #region NameProperty
        private string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { SetProperty(ref _EmployeeName, value); }
        }
        #endregion

        #region Furiganaperty
        private string _Furigana;
        public string Furigana
        {
            get { return _Furigana; }
            set { SetProperty(ref _Furigana, value); }
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
        private long? _OrganizationId;
        public long? OrganizationId
        {
            get { return _OrganizationId; }
            set { SetProperty(ref _OrganizationId, value); }
        }
        #endregion

        #region OrganizationProperty
        private Organization _Organization;
        public Organization Organization
        {
            get { return _Organization; }
            set { SetProperty(ref _Organization, value); }
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

        public async Task<Employee> PostEmployeeAsync(Employee Employee)
        {
            IRestService rest = new RestService();
            Employee createdEmployee = await rest.PostEmployeeAsync(Employee);
            return createdEmployee;
        }

        public async Task<Employee> PutEmployeeAsync(Employee Employee)
        {
            IRestService rest = new RestService();
            Employee updatedEmployee = await rest.PutEmployeeAsync(Employee);
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
