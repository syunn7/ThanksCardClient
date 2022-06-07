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

#nullable disable
namespace ThanksCardClient.ViewModels
{

    public class ClassificationMgViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        public ClassificationMgViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region ClassificationProperty
        private List<Classification> _Classification;
        public List<Classification> Classification
        {
            get { return _Classification; }
            set { SetProperty(ref _Classification, value); }
        }
        #endregion

        #region ClassificationsProperty
        private Classification _Classifications;
        public Classification Classifications
        {
            get { return _Classifications; }
            set { SetProperty(ref _Classifications, value); }
        }
        #endregion

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            Classification Classification = new Classification();
            this.Classification = await Classification.GetClassificationAsync();
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        private async void UpdateClassifications()
        {
            Classification Classification = new Classification();
            this.Classification = await Classification.GetClassificationAsync();
        }



        #region  ClassificationCreateCommand
        private DelegateCommand _ClassificationCreateCommand;
        public DelegateCommand ClassificationCreateCommand =>
            _ClassificationCreateCommand ?? (_ClassificationCreateCommand = new DelegateCommand(ExecuteClassificationCreateCommand));
        void ExecuteClassificationCreateCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.ClassificationCreate));
        }
        #endregion

        #region ClassificationEditCommand

        private DelegateCommand<Classification> _ClassificationEditCommand;
        public DelegateCommand<Classification> ClassificationEditCommand =>
            _ClassificationEditCommand ?? (_ClassificationEditCommand = new DelegateCommand<Classification>(ExecuteClassificationEditCommand));

        void ExecuteClassificationEditCommand(Classification SelectedClassification)
        {
            // 対象のEmployeeをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedClassification", SelectedClassification);

            this.regionManager.RequestNavigate("MainRegion", nameof(Views.ClassificationEdit), parameters);
        }
        #endregion

        #region ClassificationDeleteCommand
        private DelegateCommand<Classification> _ClassificationDeleteCommand;
        public DelegateCommand<Classification> ClassificationDeleteCommand =>
            _ClassificationDeleteCommand ?? (_ClassificationDeleteCommand = new DelegateCommand<Classification>(ExecuteClassificationDeleteCommand));

        async void ExecuteClassificationDeleteCommand(Classification SelectedClassification)
        {
            Classification deletedClassification = await SelectedClassification.DeleteClassificationAsync(SelectedClassification.Id);

            //分類一覧 Classification を更新する。
            this.UpdateClassifications();
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

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

