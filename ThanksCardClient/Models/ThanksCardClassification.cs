#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanksCardClient.Models
{
    public class ThanksCardClassification : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region ThanksCardIdProperty
        private long _ThanksCardId;
        public long ThanksCardId
        {
            get { return _ThanksCardId; }
            set { SetProperty(ref _ThanksCardId, value); }
        }
        #endregion

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        #region TagIdProperty
        private long _ClassificationId;
        public long ClassificationId
        {
            get { return _ClassificationId; }
            set { SetProperty(ref _ClassificationId, value); }
        }
        #endregion

        #region TagProperty
        private Classification _Classification;
        public Classification Classification
        {
            get { return _Classification; }
            set { SetProperty(ref _Classification, value); }
        }
        #endregion
    }
}
