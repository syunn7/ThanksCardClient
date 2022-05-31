#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class LogonxViewModel : BindableBase
    {
        private IRegionManager regionManager;

        #region UserProperty
        private Employee _Employee;
        public Employee Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }
        #endregion

        #region ErrorMessage
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion

        public LogonxViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            // 開発中のみアカウントを admin/admin でセットしておく。
            this.Employee = new Employee();
            this.Employee.EmployeeCd = "a0001";
            this.Employee.Password = "admin";
        }

        #region LogonxCommand
        private DelegateCommand _LogonxCommand;
        public DelegateCommand LogonxCommand =>
            _LogonxCommand ?? (_LogonxCommand = new DelegateCommand(ExecuteLogonxCommandAsync));

        async void ExecuteLogonxCommandAsync()
        {
            Employee authorizedEmployee = await this.Employee.LogonAsync();

            // authorizedUser が null でなければログオンに成功している。
            if (authorizedEmployee != null)
            {
                SessionService.Instance.IsAuthorized = true;
                SessionService.Instance.AuthorizedEmployee = authorizedEmployee;
                this.ErrorMessage = "";
                this.regionManager.RequestNavigate("HeaderRegion", nameof(Views.Header));
                this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
                this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Footer));
            }
            else
            {
                this.ErrorMessage = "ログオンに失敗しました。";
            }
        }
        #endregion
    }
}
