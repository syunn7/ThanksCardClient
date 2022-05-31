#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

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

        public ThanksCardCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        // この画面に遷移し終わったときに呼ばれる。
        // それを利用し、画面表示に必要なプロパティを初期化している。
        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.ThanksCard = new ThanksCard();
            
            if (SessionService.Instance.AuthorizedEmployee != null)
            {
                this.FromEmployees = await SessionService.Instance.AuthorizedEmployee.GetEmployeesAsync();
                this.ToEmployees = this.FromEmployees;
            }

            var classification = new Classification();
            this.Classifications = await classification.GetClassificationsAsync();

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

        #region FromDepartmentsChangedCommand
        private DelegateCommand<long?> _FromDepartmentsChangedCommand;
        public DelegateCommand<long?> FromDepartmentsChangedCommand =>
            _FromDepartmentsChangedCommand ?? (_FromDepartmentsChangedCommand = new DelegateCommand<long?>(ExecuteFromDepartmentsChangedCommand));

        async void ExecuteFromDepartmentsChangedCommand(long? FromDepartmentId)
        {
            this.FromEmployees = await SessionService.Instance.AuthorizedEmployee.GetOrganizationUsersAsync(FromOrganizationId);
        }
        #endregion

        #region ToDepartmentsChangedCommand
        private DelegateCommand<long?> _ToDepartmentsChangedCommand;
        public DelegateCommand<long?> ToDepartmentsChangedCommand =>
            _ToDepartmentsChangedCommand ?? (_ToDepartmentsChangedCommand = new DelegateCommand<long?>(ExecuteToDepartmentsChangedCommand));

        async void ExecuteToDepartmentsChangedCommand(long? ToDepartmentId)
        {
            this.ToUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(ToDepartmentId);
        }
        #endregion

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            System.Diagnostics.Debug.WriteLine(this.Tags);

            //選択された Tag を取得し、ThanksCard.ThanksCardTags にセットする。
            List<ThanksCardClassification> ThanksCardTags = new List<ThanksCardClassification>();
            foreach (var tag in this.Tags.Where(t => t.Selected))
            {
                ThanksCardClassification thanksCardTag = new ThanksCardClassification();
                thanksCardTag.TagId = tag.Id;
                ThanksCardTags.Add(thanksCardTag);
            }
            this.ThanksCard.ThanksCardTags = ThanksCardTags;

            ThanksCard createdThanksCard = await ThanksCard.PostThanksCardAsync(this.ThanksCard);

            //TODO: Error handling
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));

        }
        #endregion
    }
}
