#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class EmployeeCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region EmployeeProperty
        private Employee _Employee;
        public Employee Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }
        #endregion

        #region OrganizationsProperty
        private List<Organization> _Organizations;
        public List<Organization> Organizations
        {
            get { return _Organizations; }
            set { SetProperty(ref _Organizations, value); }
        }
        #endregion

        public EmployeeCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            Organization dept = new Organization();
            this.Organizations = await dept.GetOrganizationsAsync();

            this.Employee = new Employee();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Employee createdEmployee = await Employee.PostEmployeeAsync(this.Employee);

            this.regionManager.RequestNavigate("MainRegion", nameof(Views.EmployeeMg));
        }
        #endregion

        #region  HomeCommand
        private DelegateCommand _HomeCommand;
        public DelegateCommand HomeCommand =>
            _HomeCommand ?? (_HomeCommand = new DelegateCommand(ExecuteHomeCommand));
        void ExecuteHomeCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.Home));
        }
        #endregion
    }
}