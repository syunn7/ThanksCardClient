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
        public class ReceiveBoxViewModel : BindableBase, INavigationAware
    {
            private readonly IRegionManager regionManager;
            public ReceiveBoxViewModel(IRegionManager regionManager)
            {
                this.regionManager = regionManager;
            }

        #region ThanksCardProperty
        private List<ThanksCard> _ThanksCard;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        /*#region ReceiveThanksCardProperty
        private List<ThanksCard> _ReceiveThanksCard;
        public List<ThanksCard> ReceiveThanksCard
        {
            get { return _ReceiveThanksCard; }
            set { SetProperty(ref _ReceiveThanksCard, value); }
        }
        #endregion*/

        #region EmployeeProperty
        private List<Employee> _Employee;
        public List<Employee> Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }
        #endregion

     
        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard ThanksCard = new ThanksCard();
            this.ThanksCards = await ThanksCard.GetThanksCardsAsync();
            //this.ReceiveThanksCard = await ThanksCard.GetThanksCardsAsync();
            //this.Receives = await service.GetThanksCardsAsync();
            Employee AuthorizedEmployee = SessionService.Instance.AuthorizedEmployee;
            ThanksCards = this.ThanksCards.Where(x => x.ToId == AuthorizedEmployee.Id).ToList();
        }






        #region ThanksCardDisplayCommand
        private DelegateCommand<ThanksCard> _ThanksCardDisplayCommand;
        public DelegateCommand<ThanksCard> ThanksCardDisplayCommand =>
            _ThanksCardDisplayCommand ?? (_ThanksCardDisplayCommand = new DelegateCommand<ThanksCard>(ExecuteThanksCardDisplayCommand));

        void ExecuteThanksCardDisplayCommand(ThanksCard SelectedThanksCard)
        {
            // 対象のUserをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedThanksCard", SelectedThanksCard);

            this.regionManager.RequestNavigate("MainRegion", nameof(Views.ThanksCardDisplay), parameters);
        }
        #endregion

        #region   HomeCommand
        private DelegateCommand _HomeCommand;
            public DelegateCommand HomeCommand =>
                _HomeCommand ?? (_HomeCommand = new DelegateCommand(ExecuteHomeCommand));
            void ExecuteHomeCommand()
            {
                this.regionManager.RequestNavigate("MainRegion", nameof(Views.Home));
            }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
        #endregion
    }
    }

