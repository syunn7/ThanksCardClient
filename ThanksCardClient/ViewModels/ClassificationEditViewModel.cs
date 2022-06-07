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

namespace ThanksCardClient.ViewModels
{
    class ClassificationEditViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;


        #region ClassificationProperty
        private Classification _Classification;
        public Classification Classification
        {
            get { return _Classification; }
            set { SetProperty(ref _Classification, value); }
        }
        #endregion

        #region ClassificationsProperty
        private List<Classification> _Classifications;
        public List<Classification> Classifications
        {
            get { return _Classifications; }
            set { SetProperty(ref _Classifications, value); }
        }
        #endregion

        public ClassificationEditViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 画面遷移元から送られる SelectedClassification パラメーターを取得。
            this.Classification = navigationContext.Parameters.GetValue<Classification>("SelectedClassification");

            Classification Classification = new Classification();
            this.Classifications = await Classification.GetClassificationAsync();
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
            Classification updatedClassification = await Classification.PutClassificationAsync(this.Classification);

            this.regionManager.RequestNavigate("MainRegion", nameof(Views.ClassificationMg));
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
