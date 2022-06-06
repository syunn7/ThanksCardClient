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
    public class OrganizationMgViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region OrganizationsProperty
        private List<Organization> _Organizations;
        public List<Organization> Organizations
        {
            get { return _Organizations; }
            set { SetProperty(ref _Organizations, value); }
        }
        #endregion

        public OrganizationMgViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateOrganizations();
        }
        
        private async void UpdateOrganizations()
        {
            Organization organization = new Organization();
            this.Organizations = await organization.GetOrganizationsAsync();
        }

        #region OrganizationCreateCommand
        private DelegateCommand _OrganizationCreateCommand;
        public DelegateCommand OrganizationCreateCommand =>
            _OrganizationCreateCommand ?? (_OrganizationCreateCommand = new DelegateCommand(ExecuteOrganizationCreateCommand));

        void ExecuteOrganizationCreateCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.OrganizationCreate));
        }
        #endregion

        #region OrganizationEditCommand
        private DelegateCommand<Organization> _OrganizationEditCommand;
        public DelegateCommand<Organization> OrganizationEditCommand =>
            _OrganizationEditCommand ?? (_OrganizationEditCommand = new DelegateCommand<Organization>(ExecuteOrganizationEditCommand));

        void ExecuteOrganizationEditCommand(Organization SelectedOrganization)
        {
            // 対象のOrganizationをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedOrganization", SelectedOrganization);

            this.regionManager.RequestNavigate("MainRegion", nameof(Views.OrganizationEdit), parameters);
        }
        #endregion

        #region OrganizationDeleteCommand
        private DelegateCommand<Organization> _OrganizationDeleteCommand;
        public DelegateCommand<Organization> OrganizationDeleteCommand =>
            _OrganizationDeleteCommand ?? (_OrganizationDeleteCommand = new DelegateCommand<Organization>(ExecuteOrganizationDeleteCommand));

        async void ExecuteOrganizationDeleteCommand(Organization SelectedOrganization)
        {
            Organization deletedOrganization = await SelectedOrganization.DeleteOrganizationAsync(SelectedOrganization.Id);

            // 一覧 Organizations を更新する。
            this.UpdateOrganizations();
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
