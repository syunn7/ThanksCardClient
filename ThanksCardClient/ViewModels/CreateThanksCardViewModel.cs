#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class CreateThanksCardViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public CreateThanksCardViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        #region FromUsersProperty
        private List<Employee> _FromEmployees;
        public List<Employee> FromEmployees
        {
            get { return _FromEmployees; }
            set { SetProperty(ref _FromEmployees, value); }
        }
        #endregion

        #region ToUsersProperty
        private List<Employee> _ToEmployees;
        public List<Employee> ToEmployees
        {
            get { return _ToEmployees; }
            set { SetProperty(ref _ToEmployees, value); }
        }
        #endregion

        #region DepartmentsProperty
        private List<Organization> _Organizations;
        public List<Organization> Organizations
        {
            get { return _Organizations; }
            set { SetProperty(ref _Organizations, value); }
        }
        #endregion

        #region TagsProperty
        private List<Classification> _Classifications;
        public List<Classification> Classifications
        {
            get { return _Classifications; }
            set { SetProperty(ref _Classifications, value); }
        }
        #endregion

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.ThanksCard = new ThanksCard();

            if (SessionService.Instance.AuthorizedEmployee != null)
            {
                this.FromEmployees = await SessionService.Instance.AuthorizedEmployee.GetEmployeesAsync();
                this.ToEmployees = this.FromEmployees;
            }

            var classification = new Classification();
            this.Classifications = await classification.GetClassificationAsync();

            var organization = new Organization();
            this.Organizations = await organization.GetOrganizationsAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region FromOrganizationsChangedCommand
        private DelegateCommand<long?> _FromOrganizationsChangedCommand;
        public DelegateCommand<long?> FromOrganizationsChangedCommand =>
            _FromOrganizationsChangedCommand ?? (_FromOrganizationsChangedCommand = new DelegateCommand<long?>(ExecuteFromOrganizationsChangedCommand));

        async void ExecuteFromOrganizationsChangedCommand(long? FromOrganizationId)
        {
            this.FromEmployees = await SessionService.Instance.AuthorizedEmployee.GetOrganizationUsersAsync(FromOrganizationId);
        }
        #endregion

        #region ToOrganizationsChangedCommand
        private DelegateCommand<long?> _ToOrganizationsChangedCommand;
        public DelegateCommand<long?> ToOrganizationsChangedCommand =>
            _ToOrganizationsChangedCommand ?? (_ToOrganizationsChangedCommand = new DelegateCommand<long?>(ExecuteToOrganizationsChangedCommand));

        async void ExecuteToOrganizationsChangedCommand(long? ToOrganizationId)
        {
            this.ToEmployees = await SessionService.Instance.AuthorizedEmployee.GetOrganizationUsersAsync(ToOrganizationId);
        }
        #endregion

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            System.Diagnostics.Debug.WriteLine(this.Classifications);

            //選択された Tag を取得し、ThanksCard.ThanksCardTags にセットする。
            List<ThanksCardClassification> ThanksCardClassifications = new List<ThanksCardClassification>();
            foreach (var Classification in this.Classifications.Where(t => t.Selected))
            {
                ThanksCardClassification thanksCardClassification = new ThanksCardClassification();
                thanksCardClassification.ClassificationId = Classification.Id;
                ThanksCardClassifications.Add(thanksCardClassification);
            }
            this.ThanksCard.ThanksCardClassifications = ThanksCardClassifications;

            ThanksCard createdThanksCard = await ThanksCard.PostThanksCardAsync(this.ThanksCard);

            //TODO: Error handling
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.ThanksCardList));

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
