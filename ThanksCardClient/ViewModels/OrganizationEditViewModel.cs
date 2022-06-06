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
    public class OrganizationEditViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region OrganizationProperty
        private Organization _Organization;
        public Organization Organization
        {
            get { return _Organization; }
            set { SetProperty(ref _Organization, value); }
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

        #region ErrorMessageProperty
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion

        public OrganizationEditViewModel(IRegionManager regionManager)
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
            // 画面遷移元から送られる SelectedTag パラメーターを取得。
            this.Organization = navigationContext.Parameters.GetValue<Organization>("SelectedOrganization");

            this.UpdateOrganizations();
        }

        private async void UpdateOrganizations()
        {
            Organization organization = new Organization();
            this.Organizations = await organization.GetOrganizationsAsync();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Organization updatedOrganization = await this.Organization.PutOrganizationAsync(this.Organization);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.OrganizationMg));
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