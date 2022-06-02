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

        public HomeViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedEmployee = SessionService.Instance.AuthorizedEmployee;
        }

        #region CreateThanksCardCommand
        private DelegateCommand _CreateThanksCardCommand;
        public DelegateCommand CreateThanksCardCommand =>
            _CreateThanksCardCommand ?? (_CreateThanksCardCommand = new DelegateCommand(ExecuteCreateThanksCardCommand));

        void ExecuteCreateThanksCardCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.CreateThanksCard));
        }
        #endregion

        /*#region PastListCommand
        private DelegateCommand _PastListCommand;
        public DelegateCommand PastListCommand =>
            _PastListCommand ?? (_PastListCommand = new DelegateCommand(ExecutePastListCommand));

        void ExecutePastListCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.PastList));
        }
        #endregion*/

        #region ReceiveBoxCommand
        private DelegateCommand _ReceiveBoxCommand; 
        public DelegateCommand ReceiveBoxCommand =>
            _ReceiveBoxCommand ?? (_ReceiveBoxCommand = new DelegateCommand(ExecuteReceiveBoxCommand));

        void ExecuteReceiveBoxCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.ReceiveBox));
        }
        #endregion

        #region SendBoxCommand
        private DelegateCommand _SendBoxCommand; 
        public DelegateCommand SendBoxCommand =>
            _SendBoxCommand ?? (_SendBoxCommand = new DelegateCommand(ExecuteSendBoxCommand));

        void ExecuteSendBoxCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.SendBox));
        }
        #endregion

        #region EmployeeMgCommand
        private DelegateCommand _EmployeeMgCommand;
        public DelegateCommand EmployeeMgCommand =>
            _EmployeeMgCommand ?? (_EmployeeMgCommand = new DelegateCommand(ExecuteEmployeeMgCommand));

        void ExecuteEmployeeMgCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.EmployeeMg));
        }
        #endregion

        #region OrganizationMgCommand
        private DelegateCommand _OrganizationMgCommand;
        public DelegateCommand OrganizationMgCommand =>
            _OrganizationMgCommand ?? (_OrganizationMgCommand = new DelegateCommand(ExecuteOrganizationMgCommand));

        void ExecuteOrganizationMgCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.OrganizationMg));
        }
        #endregion

        #region ClassificationMgCommand
        private DelegateCommand _ClassificationMgCommand;
        public DelegateCommand ClassificationMgCommand =>
            _ClassificationMgCommand ?? (_ClassificationMgCommand = new DelegateCommand(ExecuteClassificationMgCommand));

        void ExecuteClassificationMgCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.ClassificationMg));
        }
        #endregion*/

        /*#region AggregationCommand
        private DelegateCommand _AggregationCommand;
        public DelegateCommand AggregationCommand =>
            _AggregationCommand ?? (_AggregationCommand = new DelegateCommand(ExecuteAggregationCommand));

        void ExecuteAggregationCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.Aggregation));
        }
        #endregion

        #region DetailListCommand
        private DelegateCommand _DetailListCommand;
        public DelegateCommand DetailListCommand =>
            _DetailListCommand ?? (_DetailListCommand = new DelegateCommand(ExecuteDetailListCommand));

        void ExecuteDetailListCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.DetailList));
        }
        #endregion*/

        #region ManualCommand
        private DelegateCommand _ManualCommand;
        public DelegateCommand ManualCommand =>
            _ManualCommand ?? (_ManualCommand = new DelegateCommand(ExecuteManualCommand));

        void ExecuteManualCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.Manual));
        }
        #endregion


        #region LogoutCommand
        private DelegateCommand _LogoutCommand;
        public DelegateCommand LogoutCommand =>
            _LogoutCommand ?? (_LogoutCommand = new DelegateCommand(ExecuteLogoutCommand));

        void ExecuteLogoutCommand()
        {
            SessionService.Instance.AuthorizedEmployee = null;
            SessionService.Instance.IsAuthorized = false;

            this.regionManager.RequestNavigate("MainRegion", nameof(Views.Login));
        }
        #endregion
    }
}
