#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ThanksCardClient.Models
{
    public class Classification : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region NameProperty
        private string _ClassificationName;
        public string ClassificationName
        {
            get { return _ClassificationName; }
            set { SetProperty(ref _ClassificationName, value); }
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

        #region SelectedProperty
        private bool _Selected;

        // JSON シリアライズから除外する
        [JsonIgnore]
        public bool Selected
        {
            get { return _Selected; }
            set { SetProperty(ref _Selected, value); }
        }
        #endregion

        public async Task<List<Classification>> GetClassificationAsync()
        {
            IRestService rest = new RestService();
            var Classifications = await rest.GetClassificationsAsync();
            return Classifications;
        }

        public async Task<Classification> PostClassificationAsync(Classification classification)
        {
            IRestService rest = new RestService();
            Classification createdClassification = await rest.PostClassificationAsync(classification);
            return createdClassification;
        }

        public async Task<Classification> PutClassificationAsync(Classification classification)
        {
            IRestService rest = new RestService();
            Classification updatedClassification = await rest.PutClassificationAsync(classification);
            return updatedClassification;
        }

        public async Task<Classification> DeleteClassificationAsync(long Id)
        {
            IRestService rest = new RestService();
            Classification deletedClassification = await rest.DeleteClassificationAsync(Id);
            return deletedClassification;
        }

    }
}
