using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace ThanksCardClient.ViewModels
{
    public class ThanksCardDisplayViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public ThanksCardDisplayViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }


        #region   HomeCommand
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