﻿#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class ThanksCard : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region TitleProperty
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        #endregion

        #region BodyProperty
        private string _Contents;
        public string Contents
        {
            get { return _Contents; }
            set { SetProperty(ref _Contents, value); }
        }
        #endregion

        #region FromIdProperty
        private long _FromId;
        public long FromId
        {
            get { return _FromId; }
            set { SetProperty(ref _FromId, value); }
        }
        #endregion

        #region FromProperty
        private Employee _From;
        public Employee From
        {
            get { return _From; }
            set { SetProperty(ref _From, value); }
        }
        #endregion

        #region ToIdProperty
        private long _ToId;
        public long ToId
        {
            get { return _ToId; }
            set { SetProperty(ref _ToId, value); }
        }
        #endregion

        #region ToProperty
        private Employee _To;
        public Employee To
        {
            get { return _To; }
            set { SetProperty(ref _To, value); }
        }
        #endregion

        #region DateProperty
        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { SetProperty(ref _Date, value); }
        }
        #endregion

        #region ThanksCardTagsProperty
        private List<ThanksCardClassification> _ThanksCardClassifications;
        public List<ThanksCardClassification> ThanksCardClassifications
        {
            get { return _ThanksCardClassifications; }
            set { SetProperty(ref _ThanksCardClassifications, value); }
        }
        #endregion


        public ThanksCard()
        {
            this.Date = DateTime.Now;
        }

        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            IRestService rest = new RestService();
            List<ThanksCard> thanksCards = await rest.GetThanksCardsAsync();
            return thanksCards;
        }

        public async Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard)
        {
            IRestService rest = new RestService();
            ThanksCard createdThanksCard = await rest.PostThanksCardAsync(thanksCard);
            return createdThanksCard;
        }

        public async Task<ThanksCard> DeleteThanksCardAsync(long Id)
        {
            IRestService rest = new RestService();
            ThanksCard deletedThanksCard = await rest.DeleteThanksCardAsync(Id);
            return deletedThanksCard;
        }

        public async Task<List<ThanksCard>> PostSearchThanksCardsAsync(SearchThanksCard searchThanksCard)
        {
            IRestService rest = new RestService();
            List<ThanksCard> thanksCards = await rest.PostSearchThanksCardsAsync(searchThanksCard);
            return thanksCards;
        }
    }
}
