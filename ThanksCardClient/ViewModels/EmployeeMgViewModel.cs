#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class EmployeeMgViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region EmployeesProperty
        private List<Employee> _Employees;
        public List<Employee> Employees
        {
            get { return _Employees; }
            set { SetProperty(ref _Employees, value); }
        }
        #endregion


        public EmployeeMgViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateEmployees();
        }

        private async void UpdateEmployees()
        {
            if (SessionService.Instance.AuthorizedEmployee != null)
            {
                this.Employees = await SessionService.Instance.AuthorizedEmployee.GetEmployeesAsync();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region EmployeeCreateCommand
        private DelegateCommand _EmployeeCreateCommand;
        public DelegateCommand EmployeeCreateCommand =>
            _EmployeeCreateCommand ?? (_EmployeeCreateCommand = new DelegateCommand(ExecuteEmployeeCreateCommand));

        void ExecuteEmployeeCreateCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.EmployeeCreate));
        }
        #endregion

        #region EmployeeEditCommand

        private DelegateCommand<Employee> _EmployeeEditCommand;
        public DelegateCommand<Employee> EmployeeEditCommand =>
            _EmployeeEditCommand ?? (_EmployeeEditCommand = new DelegateCommand<Employee>(ExecuteEmployeeEditCommand));

        void ExecuteEmployeeEditCommand(Employee SelectedEmployee)
        {
            // 対象のEmployeeをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedEmployee", SelectedEmployee);

            this.regionManager.RequestNavigate("MainRegion", nameof(Views.EmployeeEdit), parameters);
        }
        #endregion

        #region EmployeeDeleteCommand
        private DelegateCommand<Employee> _EmployeeDeleteCommand;
        public DelegateCommand<Employee> EmployeeDeleteCommand =>
            _EmployeeDeleteCommand ?? (_EmployeeDeleteCommand = new DelegateCommand<Employee>(ExecuteEmployeeDeleteCommand));

        async void ExecuteEmployeeDeleteCommand(Employee SelectedEmployee)
        {
            Employee deletedEmployee = await SelectedEmployee.DeleteEmployeeAsync(SelectedEmployee.Id);

            // ユーザ一覧 Employees を更新する。
            this.UpdateEmployees();
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