using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

#nullable disable
namespace ThanksCardClient.ViewModels
{

    public class ClassificationCreateViewModel : BindableBase
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

            #region ErrorMessageProperty
            private string _ErrorMessage;
            public string ErrorMessage
            {
                get { return _ErrorMessage; }
                set { SetProperty(ref _ErrorMessage, value); }
            }
            #endregion

            public ClassificationCreateViewModel(IRegionManager regionManager)
            {
                this.regionManager = regionManager;

                this.Classification = new Classification();
            }

           
               

            #region SubmitCommand
            private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Classification CreateClassification = await Classification.PostClassificationAsync(this.Classification);

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

