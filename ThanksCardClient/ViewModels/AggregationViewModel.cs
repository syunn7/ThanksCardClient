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
    internal class AggregationViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;


        #region AnalyzeDtoDsProperty
        private List<AnalyzeDtoD> _AnalyzeDtoDs;
        public List<AnalyzeDtoD> AnalyzeDtoDs
        {
            get { return _AnalyzeDtoDs; }
            set { SetProperty(ref _AnalyzeDtoDs, value); }
        }
        #endregion

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateAnalyzeDtoDs();
        }

        private async void UpdateAnalyzeDtoDs()
        {
            AnalyzeDtoD analyzeDtoD = new AnalyzeDtoD();
            this.AnalyzeDtoDs = await analyzeDtoD.GetAnalyzeDtoDsAsync();
        }

        public AggregationViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

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
