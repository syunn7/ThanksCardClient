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
    public class Organization : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region CodeProperty
        private int _OrganizationCd;
        public int OrganizationCd
        {
            get { return _OrganizationCd; }
            set { SetProperty(ref _OrganizationCd, value); }
        }
        #endregion

        #region NameProperty
        private string _OrganizationName;
        public string OrganizationName
        {
            get { return _OrganizationName; }
            set { SetProperty(ref _OrganizationName, value); }
        }
        #endregion

        #region ParentIdProperty
        private long? _ParentId;
        public long? ParentId
        {
            get { return _ParentId; }
            set { SetProperty(ref _ParentId, value); }
        }
        #endregion

        #region ParentProperty
        private Organization _Parent;
        public Organization Parent
        {
            get { return _Parent; }
            set { SetProperty(ref _Parent, value); }
        }
        #endregion

        #region ChildrenProperty
        private List<Organization> _Children;
        public List<Organization> Children
        {
            get { return _Children; }
            set { SetProperty(ref _Children, value); }
        }
        #endregion

        #region UsersProperty
        private List<Employee> _Employees;
        public List<Employee> Employees
        {
            get { return _Employees; }
            set { SetProperty(ref _Employees, value); }
        }
        #endregion

        public async Task<List<Organization>> GetOrganizationsAsync()
        {
            IRestService rest = new RestService();
            List<Organization> Organizations = await rest.GetOrganizationsAsync();
            return Organizations;
        }

        public async Task<Organization> PostOrganizationAsync(Organization Organization)
        {
            IRestService rest = new RestService();
            Organization createdOrganization = await rest.PostOrganizationAsync(Organization);
            return createdOrganization;
        }

        public async Task<Organization> PutOrganizationAsync(Organization organization)
        {
            IRestService rest = new RestService();
            Organization updatedOrganization = await rest.PutOrganizationAsync(organization);
            return updatedOrganization;
        }

        public async Task<Organization> DeleteOrganizationAsync(long Id)
        {
            IRestService rest = new RestService();
            Organization deletedOrganization = await rest.DeleteOrganizationAsync(Id);
            return deletedOrganization;
        }
    }
}
