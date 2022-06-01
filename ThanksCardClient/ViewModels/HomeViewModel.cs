#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    internal class HomeViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private Employee _AuthorizedEmployee;
        public Employee AuthorizedEmployee
        {
            get { return _AuthorizedEmployee; }
            set { SetProperty(ref _AuthorizedEmployee, value); }
        }

        #region LogoutCommand
        private DelegateCommand _logoutCommand;
        public DelegateCommand LogoutCommand =>
            _logoutCommand ?? (_logoutCommand = new DelegateCommand(ExecuteLogoutCommand));

        void ExecuteLogoutCommand()
        {
            SessionService.Instance.AuthorizedEmployee = null;
            SessionService.Instance.IsAuthorized = false;

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Logon));
        }
        #endregion
    }
}
