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
    public class ListThanksCardViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
        }
        #endregion

        public ListThanksCardViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        async void UpdateThanksCard()
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();
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

        #region DeleteThanksCardCommand
        private DelegateCommand<ThanksCard> _DeleteThanksCardCommand;
        public DelegateCommand<ThanksCard> DeleteThanksCardCommand =>
            _DeleteThanksCardCommand ?? (_DeleteThanksCardCommand = new DelegateCommand<ThanksCard>(ExcuteDeleteThanksCardCommand));

        async void ExcuteDeleteThanksCardCommand(ThanksCard SelectedThanksCard)
        {
            ThanksCard thanksCard = await SelectedThanksCard.DeleteThanksCardAsync(SelectedThanksCard.Id);
            this.UpdateThanksCard();
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